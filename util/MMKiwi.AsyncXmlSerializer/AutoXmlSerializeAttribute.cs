namespace MMKiwi.AsyncXmlSerializer;

public class AutoXmlSerializeAttribute : Attribute
{
    public AutoXmlSerializeAttribute()
    {
    }

    public AutoXmlSerializeAttribute(NullableHandling nullable, string? defaultName)
    {
        Nullable = nullable;
        DefaultName = defaultName;
    }

    public NullableHandling Nullable { get; set; }
    public string? DefaultName {get;set;}
}
