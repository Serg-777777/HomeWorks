namespace HW_Reflection;

internal class Container
{
    public string? Description { set; get; }
    public double? Volume { set; get; }
    public double? Weight { set; get; }
    [IgnoreField]
    public string? Password { get; set; }
}