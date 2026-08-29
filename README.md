[![](https://img.shields.io/nuget/v/soenneker.validators.phone.possible.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.phone.possible/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.phone.possible/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.phone.possible/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.phone.possible.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.phone.possible/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.phone.possible/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.phone.possible/actions/workflows/codeql.yml)

# Soenneker.Validators.Phone.Possible

Validates whether a given phone number is possible and valid for a specific region.

## Install

```bash
dotnet add package Soenneker.Validators.Phone.Possible
```

## Quick start

```csharp
using Soenneker.Validators.Phone.Possible.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddPhonePossibleValidatorAsSingleton();
```

Adds `IPhonePossibleValidator` as a singleton service.

## What you get

- `IPhonePossibleValidator` — Validates whether a given phone number is possible and valid for a specific region.
- `PhonePossibleValidatorRegistrar` — A validation module checking if a given phone number is possible.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IPhonePossibleValidator.Parse(number, defaultRegion, cancellationToken)` | Parses a raw phone number string into a `PhoneNumber` object. | A `PhoneNumber` object if parsing succeeds; otherwise, `null`. |
| `PhonePossibleValidatorRegistrar.AddPhonePossibleValidatorAsSingleton(services)` | Adds `IPhonePossibleValidator` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `PhonePossibleValidatorRegistrar.AddPhonePossibleValidatorAsScoped(services)` | Adds `IPhonePossibleValidator` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
