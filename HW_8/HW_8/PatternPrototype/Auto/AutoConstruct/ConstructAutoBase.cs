

using HW_8.PatternPrototype.Auto.Cars;
using HW_8.PatternPrototype.Cloner;

namespace HW_8.PatternPrototype.Auto.AutoConstruct;

internal abstract class ConstructAutoBase : IConstructAuto<ConstructAutoBase>
{
    private IAutoPartsSetting<AutoBase> _autoParts = default!;

    public ConstructAutoBase(IAutoPartsSetting<AutoBase> autoParts)
    {
        _autoParts = autoParts;
    }

    public virtual IClonerAuto Cloner()
    {
        var cloner = new ClonerAuto(_autoParts!.GetAutoBase());
        return cloner;
    }
    public ConstructAutoBase CreateBody((string type, string color) body)
    {
        IBody _body = Activator.CreateInstance<IBody>();
        _body.ColorBody = body.color;
        _body.TypeBody = body.type;
        _autoParts.SetBody(_body);
        return this;
    }
    public ConstructAutoBase CreateEngie((double volume, double horses, int speed) engie)
    {
        IEngie _engie = Activator.CreateInstance<IEngie>();
        _engie.Horsepower = engie.horses;
        _engie.Volume = engie.volume;
        _engie.Speed = engie.speed;
        _autoParts.SetEngie(_engie);
        return this;
    }
    public ConstructAutoBase CreateInfo((string model, string dateStart, string dateEnd) info)
    {
        IInfo _info = Activator.CreateInstance<IInfo>();
        _info.Model = info.model;
        _info.DateProduceStart = info.dateStart;
        _info.DateProduceEnd = info.dateEnd;
        _autoParts.SetInfo(_info);
        return this;
    }
}
