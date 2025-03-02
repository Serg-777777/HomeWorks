using System.Text.Json;


using HW_8.PatternPrototype.Auto;

namespace HW_8.PatternPrototype.Cloner;

internal class ClonerAuto : IClonerAuto
{
   private AutoBase? _autoOriginal{ get; set; }
    public ClonerAuto(AutoBase original)
    {
        _autoOriginal = original;
    }
    public virtual object Clone()
    {
        var str = GetCloneJSON();
        var obj = JsonSerializer.Deserialize<AutoBase>(str);
        return obj!;
    }

    public string GetCloneJSON()
    {
        var str = JsonSerializer.Serialize<AutoBase>(_autoOriginal!);
        return str;
    }

    public string GetCloneXML()
    {
        throw new NotImplementedException("In process");
    }
}
