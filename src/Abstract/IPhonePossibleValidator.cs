using PhoneNumbers;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Validators.Phone.Possible.Abstract;

/// <summary>
/// Validates whether a given phone number is possible and valid for a specific region.
/// </summary>
public interface IPhonePossibleValidator
{
    /// <summary>
    /// Parses a raw phone number string into a <see cref="PhoneNumber"/> object.
    /// </summary>
    /// <param name="number">The phone number to parse.</param>
    /// <param name="defaultRegion">The default region code (e.g., "US").</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="PhoneNumber"/> object if parsing succeeds; otherwise, <c>null</c>.</returns>
    ValueTask<PhoneNumber?> Parse(string number, string defaultRegion = "US", CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates whether a <see cref="PhoneNumber"/> object is valid for the specified region.
    /// </summary>
    /// <param name="phoneNumber">The parsed phone number to validate.</param>
    /// <param name="defaultRegion">The region code to validate against (e.g., "US").</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns><c>true</c> if the phone number is valid; <c>false</c> if invalid; <c>null</c> if validation fails.</returns>
    ValueTask<bool?> Validate(PhoneNumber phoneNumber, string defaultRegion = "US", CancellationToken cancellationToken = default);

    /// <summary>
    /// Parses and validates a raw phone number string for the specified region.
    /// </summary>
    /// <param name="phoneNumber">The raw phone number string to validate.</param>
    /// <param name="defaultRegion">The region code to validate against (e.g., "US").</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns><c>true</c> if the phone number is valid; <c>false</c> if invalid; <c>null</c> if parsing fails.</returns>
    ValueTask<bool?> Validate(string phoneNumber, string defaultRegion = "US", CancellationToken cancellationToken = default);
}