using TheTimeLedger.SharedKernel.Abstractions;

namespace TheTimeLedger.SharedKernel.Primitives
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }
}
