using Soenneker.Validators.Phone.Possible.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Validators.Phone.Possible.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class PhonePossibleValidatorTests : HostedUnitTest
{
    private readonly IPhonePossibleValidator _validator;

    public PhonePossibleValidatorTests(Host host) : base(host)
    {
        _validator = Resolve<IPhonePossibleValidator>(true);
    }

    [Test]
    public void Default()
    {

    }
}
