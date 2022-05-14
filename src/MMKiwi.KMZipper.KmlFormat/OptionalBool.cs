using System.Xml.Schema;

namespace MMKiwi.KMZipper.KmlFormat;

public class OptionalBool : IXmlSerializable, IEquatable<OptionalBool>, IEquatable<object>
{
    public OptionalBool() { }
    public OptionalBool(bool value) => Value = value;
    public bool Value { get; set; }

    public static bool operator ==(OptionalBool? ob1, OptionalBool? ob2)
    {
        if (System.Object.ReferenceEquals(ob1, ob2))
        {
            return true;
        }
        if (ob1 is null || ob2 == null)
        {
            return false;
        }
        return ob1.Value == ob2.Value;
    }

    public static bool operator !=(OptionalBool? ob1, OptionalBool? ob2) => !(ob1 == ob2);

    public bool Equals(OptionalBool other) => other != null && other.Value == Value;

    public override bool Equals(object other)
    {
        if (other is OptionalBool otherC)
            return other.Equals(otherC);
        else if (other is bool otherB)
            return Value == otherB;
        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();

    public string ToString(IFormatProvider ifp) => Value.ToString(ifp);

    public XmlSchema? GetSchema() => null;
    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        if (!reader.IsEmptyElement)
            Value = bool.Parse(reader.ReadInnerXml());
    }
    public void WriteXml(XmlWriter writer) => writer.WriteString(Value ? "true" : "false");

    public static implicit operator bool(OptionalBool ob) => ob.Value;
    public static implicit operator OptionalBool(bool b) => new OptionalBool(b);
}