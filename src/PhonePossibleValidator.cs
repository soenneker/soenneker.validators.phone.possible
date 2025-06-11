using Microsoft.Extensions.Logging;
using PhoneNumbers;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.Libphonenumber.Abstract;
using Soenneker.Validators.Phone.Possible.Abstract;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Validators.Phone.Possible;

/// <inheritdoc cref="IPhonePossibleValidator"/>
public sealed class PhonePossibleValidator : Validator.Validator, IPhonePossibleValidator
{
    private readonly ILibphonenumberUtil _libphonenumberUtil;

    public PhonePossibleValidator(ILogger<PhonePossibleValidator> logger, ILibphonenumberUtil libphonenumberUtil) : base(logger)
    {
        _libphonenumberUtil = libphonenumberUtil;
    }

    public async ValueTask<PhoneNumber?> Parse(string number, string defaultRegion = "US", CancellationToken cancellationToken = default)
    {
        PhoneNumberUtil instance = await _libphonenumberUtil.Get(cancellationToken).NoSync();

        try
        {
            return instance.Parse(number, defaultRegion);
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<bool?> Validate(PhoneNumber phoneNumber, string defaultRegion = "US", CancellationToken cancellationToken = default)
    {
        PhoneNumberUtil instance = await _libphonenumberUtil.Get(cancellationToken).NoSync();

        return instance.IsValidNumberForRegion(phoneNumber, defaultRegion);
    }

    public async ValueTask<bool?> Validate(string phoneNumber, string defaultRegion = "US", CancellationToken cancellationToken = default)
    {
        PhoneNumberUtil instance = await _libphonenumberUtil.Get(cancellationToken).NoSync();

        PhoneNumber? parsedPhoneNumber = await Parse(phoneNumber, defaultRegion, cancellationToken).NoSync();

        if (parsedPhoneNumber == null)
            return false;

        return instance.IsValidNumberForRegion(parsedPhoneNumber, defaultRegion);
    }

    /// <summary>
    /// You should use the non-static methods if possible.
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <param name="defaultRegion"></param>
    /// <returns></returns>
    [Pure]
    public static bool? ValidateStatic(PhoneNumber phoneNumber, string defaultRegion = "US")
    {
        var instance = PhoneNumberUtil.GetInstance();
        return instance.IsValidNumberForRegion(phoneNumber, defaultRegion);
    }
}