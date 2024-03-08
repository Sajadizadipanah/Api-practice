using FluentValidation;

namespace API_Practice.Dtos;

public class AddProductDto
{
    public string Name { get; set; }
    public int PhoneNumber { get; set; }

}

public class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter valid PhoneNumber");
        
    }
}