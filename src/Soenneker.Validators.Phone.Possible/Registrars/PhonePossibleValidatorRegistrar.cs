using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Libphonenumber.Registrars;
using Soenneker.Validators.Phone.Possible.Abstract;

namespace Soenneker.Validators.Phone.Possible.Registrars;

/// <summary>
/// A validation module checking if a given phone number is possible
/// </summary>
public static class PhonePossibleValidatorRegistrar
{
    /// <summary>
    /// Adds <see cref="IPhonePossibleValidator"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPhonePossibleValidatorAsSingleton(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddSingleton<IPhonePossibleValidator, PhonePossibleValidator>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPhonePossibleValidator"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPhonePossibleValidatorAsScoped(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddScoped<IPhonePossibleValidator, PhonePossibleValidator>();

        return services;
    }
}