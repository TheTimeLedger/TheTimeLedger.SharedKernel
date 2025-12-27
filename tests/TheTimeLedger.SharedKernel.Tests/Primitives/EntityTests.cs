using TheTimeLedger.SharedKernel.Primitives;
namespace TheTimeLedger.SharedKernel.Tests.Primitives;
public class TestEntity : Entity
{
    public TestEntity(Guid id) : base(id) { }
}

public class EntityTests
{
    [Fact]
    public void Entities_With_Same_Id_Are_Equal()
    {
        var id = Guid.NewGuid();

        var e1 = new TestEntity(id);
        var e2 = new TestEntity(id);

        Assert.Equal(e1, e2);
    }

    [Fact]
    public void Entities_With_Different_Ids_Are_Not_Equal()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var e1 = new TestEntity(id1);
        var e2 = new TestEntity(id2);

        Assert.NotEqual(e1, e2);
    }

    [Fact]
    public void Entity_Compared_To_Null_Returns_False()
    {
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        Assert.False(entity.Equals(null));
    }

    [Fact]
    public void Entity_Compared_To_Non_Entity_Returns_False()
    {
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);
        var nonEntity = "not an entity";

        Assert.False(entity.Equals(nonEntity));
    }

    [Fact]
    public void Entity_Compared_To_Itself_Returns_True()
    {
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        Assert.True(entity.Equals(entity));
    }

    [Fact]
    public void Entities_With_Same_Id_Have_Same_HashCode()
    {
        var id = Guid.NewGuid();

        var e1 = new TestEntity(id);
        var e2 = new TestEntity(id);

        Assert.Equal(e1.GetHashCode(), e2.GetHashCode());
    }

    [Fact]
    public void Constructor_Sets_Id_Property()
    {
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        Assert.Equal(id, entity.Id);
    }

    [Fact]
    public void GetHashCode_Returns_Id_HashCode()
    {
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        Assert.Equal(id.GetHashCode(), entity.GetHashCode());
    }
}
