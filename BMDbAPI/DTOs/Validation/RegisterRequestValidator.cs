using FluentValidation;

namespace BMDbAPI.DTOs.Validation;

/// <summary>
///   This class is used to validate the RegisterRequestDto.
/// </summary>
public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    /// <summary>
    ///  This constructor is used to validate the RegisterRequestDto.
    /// </summary>
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Password(mustContainDigit: false);
    }
}