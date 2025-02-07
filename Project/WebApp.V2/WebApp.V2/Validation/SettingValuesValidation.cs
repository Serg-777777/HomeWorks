namespace Presentation.Validation;

public class SettingValuesValidation
{
    private static SettingValuesValidation Instance = default!;

    public readonly int NameMax = 100;
    public readonly int NameMin = 5;
    public readonly int PasswordMax = 10;
    public readonly int PasswordMin = 5;
    public readonly char[] CharsNotContaints = { ' ', '<', '>', '=', ',' };

    public static SettingValuesValidation GetInstance()
    {
        if (Instance == default)
            Instance = Nested.SettingValues;
        return Instance;
    }

    private class Nested
    {
        internal static SettingValuesValidation SettingValues = new();
    }
}
