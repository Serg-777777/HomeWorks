

namespace HW_8.PatternPrototype.Auto.Cars;

internal interface IAutoPartsSetting<RAuto> where RAuto : AutoBase
{
    RAuto GetAutoBase();
    void SetInfo(IInfo info);
    void SetEngie(IEngie engie);
    void SetBody(IBody body);
}
