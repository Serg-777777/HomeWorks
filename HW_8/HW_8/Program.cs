

using HW_8.PatternPrototype.Auto;

using HW_8.PatternPrototype.Auto.Cars.Brands.Toyota;
using HW_8.PatternPrototype.Auto.Cars.Brands.UAZ;
using HW_8.PatternPrototype.Cloner;
using HW_8.PatternPrototype.Factory;

public static class Program
{
    private static readonly string _model = "Land Crouser I ";
    private static readonly string _dateStart = "01.01.2015";
    private static readonly string _dateEnd = "01.01.2022";

    private static readonly string _bodyType = "off-road";
    private static readonly string _bodyColor = "black";

    private static readonly double _volume = 2.5;
    private static readonly double _horses = 250;
    private static readonly int _speed = 200;
    
    public static void Main()
    {


    }
    private static void ProduceToyota()
    {
        Toyota toyota = new Toyota();
        ToyotaConstructor toyotaConstructor = new(toyota);
        IClonerAuto cloner = toyotaConstructor
            .CreateBody((_bodyType, _bodyColor))
            .CreateEngie((_volume, _horses, _speed))
            .CreateInfo((_model, _dateStart, _dateEnd))
            .Cloner();

        AutoFactory factory = new AutoFactory(cloner);
        AutoBase sample = factory.ProduceSample(); // глубокое копирование - прототип
        ICollection<AutoBase> batch = factory.ProduceBatch(1000); // глубокое копирование - массив прототипов
    }


    private static AutoBase GetCloneUaz()
    {
        var uazBase = NewAutoUaz();
        var cloner = new UAZConstructor(uazBase).Cloner();
        var clone = (AutoBase)cloner.Clone(); // глубокое копирование - прототип
        return clone;
    }

    private static Uaz NewAutoUaz()
    {
        Uaz uaz = new();
        IBody body = Activator.CreateInstance<IBody>();
        IEngie engie = Activator.CreateInstance<IEngie>();

        IInfo info = Activator.CreateInstance<IInfo>();
        info.Model = "Patriot";
        info.DateProduceStart = "01.01.2000";
        info.DateProduceEnd = "now";

        uaz.SetBody(body);
        uaz.SetEngie(engie);
        uaz.SetInfo(info);

        return uaz!;
    }
}
