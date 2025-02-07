namespace Application.Validation;

public class ResultValidation
{
    public bool IsValid { get; init; }
    public string MsgText { get; init; }
    public ResultValidation(bool isValid, string msgText)
    {
        IsValid = isValid;
        MsgText = msgText;
    }
}
