

namespace HW_5;

internal class ValueObject
{
    public float Value { get; init; }
    public string Desc { get; init; }

    public ValueObject(float value)
    {
        Value = value;
        Desc = $"Description {value}";
    }
}
