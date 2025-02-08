namespace Presentation.Validation;

public class SettingsValuesValidation
{
    private static SettingsValuesValidation Instance = default!;

    public readonly int NameMax = 150;
    public readonly int NameMin = 5;
    public readonly int PasswordMax = 15;
    public readonly int PasswordMin = 5;
    public readonly int EmaiMin = 10;
    public readonly int EmaiMax= 200;
    public readonly int IdMax = 6;
    public readonly int IdMin = 1;
    public readonly char[] CharsNotContaints = { ' ', '<', '>', '=', ',' };
    

    public static SettingsValuesValidation GetInstance()
    {
        if (Instance == default)
            Instance = Nested.SettingValues;
        return Instance;
    }

    private class Nested
    {
        internal static SettingsValuesValidation SettingValues = new();
    }
}
