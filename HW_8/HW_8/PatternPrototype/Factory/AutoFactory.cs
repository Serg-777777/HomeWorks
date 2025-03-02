
using HW_8.PatternPrototype.Auto;
using HW_8.PatternPrototype.Cloner;

namespace HW_8.PatternPrototype.Factory;

internal class AutoFactory : IFactory<IClonerAuto, AutoBase>
{
    private IClonerAuto? _clonerAuto = null;
    private List<AutoBase>? _autoBase = null;
    internal AutoFactory(IClonerAuto cloner)
    {
        _clonerAuto = cloner;
    }

    public ICollection<AutoBase> ProduceBatch(int count)
    {
        _autoBase = new();
        for(int i = 1; i<=count; i++)
        {
            AutoBase clone = ProduceSample();
            _autoBase.Add(clone);
        }
        return _autoBase;
    }

    public AutoBase ProduceSample()
    {
        AutoBase clone = (AutoBase)_clonerAuto!.Clone();
        return clone;
    }
}
