using HW_8.PatternPrototype.Auto;
using HW_8.PatternPrototype.Cloner;

namespace HW_8.PatternPrototype.Factory;

internal interface IFactory<in ICloning, Item> where ICloning: IClonerAuto where Item : AutoBase
{
    ICollection<Item> ProduceBatch(int count);
    Item ProduceSample();
}
