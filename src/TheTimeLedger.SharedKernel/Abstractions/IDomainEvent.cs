namespace TheTimeLedger.SharedKernel.Abstractions
{
    public interface IDomainEvent
    {
        DateTime OccurredAt { get; }
    }
}
