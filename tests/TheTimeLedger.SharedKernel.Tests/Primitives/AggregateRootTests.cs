using TheTimeLedger.SharedKernel.Primitives;
using TheTimeLedger.SharedKernel.Abstractions;
using System.Linq;
namespace TheTimeLedger.SharedKernel.Tests.Primitives;
public class TestEvent : DomainEvent { }

public class TestAggregate : AggregateRoot
{
    public TestAggregate(Guid id) : base(id) { }

    public void DoSomething()
    {
        AddDomainEvent(new TestEvent());
    }
}

public class AggregateRootTests
{
    [Fact]
    public void Aggregate_Adds_Domain_Event()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());

        aggregate.DoSomething();

        Assert.Single(aggregate.DomainEvents);
    }

    [Fact]
    public void New_Aggregate_Has_Empty_Domain_Events()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());

        Assert.Empty(aggregate.DomainEvents);
    }

    [Fact]
    public void Aggregate_Can_Add_Multiple_Domain_Events()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());

        aggregate.DoSomething();
        aggregate.DoSomething();
        aggregate.DoSomething();

        Assert.Equal(3, aggregate.DomainEvents.Count);
    }

    [Fact]
    public void ClearDomainEvents_Removes_All_Events()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());
        
        // Add some events
        aggregate.DoSomething();
        aggregate.DoSomething();
        
        // Verify events are there
        Assert.Equal(2, aggregate.DomainEvents.Count);
        
        // Clear events
        aggregate.ClearDomainEvents();
        
        // Verify events are cleared
        Assert.Empty(aggregate.DomainEvents);
    }

    [Fact]
    public void ClearDomainEvents_On_Empty_Aggregate_Does_Nothing()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());

        aggregate.ClearDomainEvents();

        Assert.Empty(aggregate.DomainEvents);
    }

    [Fact]
    public void DomainEvents_Returns_ReadOnly_Collection()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());
        aggregate.DoSomething();

        var domainEvents = aggregate.DomainEvents;

        Assert.IsAssignableFrom<IReadOnlyCollection<IDomainEvent>>(domainEvents);
    }

    [Fact]
    public void Constructor_Sets_Id_Correctly()
    {
        var id = Guid.NewGuid();
        var aggregate = new TestAggregate(id);

        Assert.Equal(id, aggregate.Id);
    }

    [Fact]
    public void Added_Domain_Event_Is_Retrievable()
    {
        var aggregate = new TestAggregate(Guid.NewGuid());
        
        aggregate.DoSomething();
        
        var domainEvent = aggregate.DomainEvents.First();
        Assert.IsType<TestEvent>(domainEvent);
    }
}
