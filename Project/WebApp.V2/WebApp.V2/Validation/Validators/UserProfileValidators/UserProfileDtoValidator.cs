using FluentValidation;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation.Validators.UserProfileValidators;

public class UserProfileDtoValidator:AbstractValidator<UserProfileDtoView>
{
    public UserProfileDtoValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(ValidationSettings.FirstNameMaxLength)
            .MinimumLength(ValidationSettings.MinLength)
            .WithMessage("FirstName is not correct");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(ValidationSettings.LastNameMaxLength)
            .MinimumLength(ValidationSettings.MinLength)
            .WithMessage("LastName is not correct");

        RuleFor(p => p.City)
            .NotEmpty()
            .NotNull()
            .MaximumLength(ValidationSettings.CityMaxLength)
            .MinimumLength(ValidationSettings.MinLength)
            .WithMessage("City is not correct");

        RuleFor(p => p.Country)
            .NotEmpty()
            .NotNull()
            .MaximumLength(ValidationSettings.CountryMaxLength)
            .MinimumLength(ValidationSettings.MinLength)
            .WithMessage("Country is not correct");

        RuleFor(p => p.Age)
            .InclusiveBetween(ValidationSettings.AgeMin, ValidationSettings.AgeMax)
            .WithMessage("Age is not correct");

    }
}
