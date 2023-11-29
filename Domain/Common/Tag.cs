namespace Domain.Common;

public class Tag
{
    public string Brand { get; private set; }
    public string Value { get; private set; }
    public IEnumerable<string> Options { get; private set; }

    public Tag(string brand, string value, IEnumerable<string> options)
    {
        Brand = brand;
        Value = value;
        Options = options;
    }
}