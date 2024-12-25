namespace Presentation.Mappers.DtoViews.UserDtoViews;

public class UserProfileDtoView : IUserDtoView
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public int? Age { get; set; }
    public int? UserModelId { get; set; }
}
