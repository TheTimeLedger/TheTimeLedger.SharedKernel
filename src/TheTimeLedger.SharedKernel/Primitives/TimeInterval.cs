namespace TheTimeLedger.SharedKernel.Primitives;

/// <summary>
/// Pure time interval primitive (no domain semantics).
/// Consumers define rules such as overlap, inclusivity, rounding, etc.
/// </summary>
public sealed record TimeInterval(DateTimeOffset Start, DateTimeOffset End);
