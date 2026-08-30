[![](https://img.shields.io/nuget/v/soenneker.validators.phone.possible.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.phone.possible/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.phone.possible/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.phone.possible/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.phone.possible.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.phone.possible/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.phone.possible/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.phone.possible/actions/workflows/codeql.yml)

# Soenneker.Validators.Phone.Possible

Parses phone numbers and checks libphonenumber's region-specific validity metadata.

## Install

```bash
dotnet add package Soenneker.Validators.Phone.Possible
```

## Registration

```csharp
using Soenneker.Validators.Phone.Possible.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddPhonePossibleValidatorAsSingleton();
```

Scoped registration is also available. Both registrations reuse the singleton libphonenumber utility, so a scoped validator can be released without rebuilding the shared metadata-backed client.

## Parse a number

```csharp
using PhoneNumbers;
using Soenneker.Validators.Phone.Possible.Abstract;

PhoneNumber? parsed = await validator.Parse(
    "+1 312-555-0187",
    defaultRegion: "US",
    cancellationToken);
```

The default region is used to interpret national-format input. International input beginning with `+` carries its own country calling code. Expected libphonenumber parse failures return `null`; cancellation while obtaining the shared utility and unexpected runtime failures propagate.

## Validate raw or parsed input

```csharp
bool? validRaw = await validator.Validate(
    "312-555-0187",
    defaultRegion: "US",
    cancellationToken);

bool? validParsed = await validator.Validate(
    parsed!,
    defaultRegion: "US",
    cancellationToken);
```

The raw overload returns `false` when parsing fails. Both overloads call `PhoneNumberUtil.IsValidNumberForRegion`; despite the package name, they do not call `IsPossibleNumber`. Region validity is stricter than a length-only possibility check and requires the parsed number to belong to the requested region.

The nullable Boolean return type is retained by the API, but the current validation implementations return only `true` or `false`.

## Static access

```csharp
bool? valid = PhonePossibleValidator.ValidateStatic(parsed!, "US");
```

The static method uses libphonenumber's process-wide instance directly. Prefer the injected API when consistent dependency ownership and cancellation during lazy initialization matter.

## What validity means

Libphonenumber validity means the number matches numbering-plan metadata. It does not prove that the number is assigned, reachable, currently active, or controlled by a user. Use an actual verification flow before trusting ownership.

Metadata can change as numbering plans evolve, so results can differ after dependency updates. Region codes are ISO-style values such as `US` or `GB`; invalid region/input combinations fail parsing or validation according to libphonenumber.
