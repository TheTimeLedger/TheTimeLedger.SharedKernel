using TheTimeLedger.SharedKernel.Primitives;

namespace TheTimeLedger.SharedKernel.Tests.Primitives;

public class TimeIntervalTests
{
    [Fact]
    public void Should_store_start_and_end()
    {
        var start = DateTimeOffset.Parse("2025-01-01T10:00:00+00:00");
        var end = DateTimeOffset.Parse("2025-01-01T11:00:00+00:00");

        var interval = new TimeInterval(start, end);

        Assert.Equal(start, interval.Start);
        Assert.Equal(end, interval.End);
    }
}
