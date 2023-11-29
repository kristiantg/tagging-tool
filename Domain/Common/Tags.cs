namespace Domain.Common;

public sealed class Tags
{
    public IEnumerable<Tag> Value { get; }

    public Tags(IEnumerable<Tag> value)
    {
        Value = value;
    }
}