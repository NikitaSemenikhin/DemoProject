namespace DemoProject.Experiments;


public sealed class PoorlyHashedObject : HashedObject
{
    public PoorlyHashedObject(int value)
        : base(value)
    {
    }

    public override int GetHashCode() => 1;
}

public sealed class ProperlyHashedObject : HashedObject
{
    public ProperlyHashedObject(int value)
        : base(value)
    {
    }

    public override int GetHashCode() => Value;
}

public abstract class HashedObject
{
    protected HashedObject(int value)
    {
        Value = value;
    }

    protected int Value { get; }

    public override bool Equals(object? obj) =>
        obj is HashedObject hashedObject &&
        hashedObject.Value == Value;
}
