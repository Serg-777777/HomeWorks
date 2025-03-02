using HW_8.PatternPrototype.Auto;

namespace HW_8.PatternPrototype.Cloner;

internal interface IClonerAuto : ICloneable
{
    string GetCloneJSON();
    string GetCloneXML();
}
