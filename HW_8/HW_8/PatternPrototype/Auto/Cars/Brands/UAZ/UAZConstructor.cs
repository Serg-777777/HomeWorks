
using HW_8.PatternPrototype.Auto.AutoConstruct;
using HW_8.PatternPrototype.Cloner;

namespace HW_8.PatternPrototype.Auto.Cars.Brands.UAZ;

internal class UAZConstructor : ConstructAutoBase
{
    public UAZConstructor(IAutoPartsSetting<AutoBase> autoParts) : base(autoParts)
    {
    }
}
