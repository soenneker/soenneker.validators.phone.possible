using Soenneker.Validators.Phone.Possible.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Validators.Phone.Possible.Tests;

[Collection("Collection")]
public class PhonePossibleValidatorTests : FixturedUnitTest
{
    private readonly IPhonePossibleValidator _validator;

    public PhonePossibleValidatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _validator = Resolve<IPhonePossibleValidator>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
