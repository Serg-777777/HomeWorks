using HW_8.PatternPrototype.Auto.AutoConstruct;
using HW_8.PatternPrototype.Cloner;

namespace HW_8.PatternPrototype.Auto.Cars.Brands.Toyota;

internal class ToyotaConstructor : ConstructAutoBase
{
    public ToyotaConstructor(IAutoPartsSetting<AutoBase> autoParts) : base(autoParts)
    {
    }
}
