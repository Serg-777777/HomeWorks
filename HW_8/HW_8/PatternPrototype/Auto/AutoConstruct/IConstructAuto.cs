
namespace HW_8.PatternPrototype.Auto.AutoConstruct;

internal interface IConstructAuto<out OAuto> where OAuto : class
{
    OAuto CreateBody((string type, string color) body);
    OAuto CreateEngie((double volume, double horses, int speed) engie);
    OAuto CreateInfo((string model, string dateStart, string dateEnd) info);
}
