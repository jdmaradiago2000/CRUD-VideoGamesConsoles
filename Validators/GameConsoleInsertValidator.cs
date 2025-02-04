using CRUD_VideoGamesConsoles.DTOs;

using FluentValidation;

namespace CRUD_VideoGamesConsoles.Validators
{
    public class GameConsoleInsertValidator : AbstractValidator<GameConsoleInsertDto>
    {
        public GameConsoleInsertValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name is Mandatory.");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("The length of the name has to be between 2 and 20 characters.");
            RuleFor(x => x.BrandID).NotNull().WithMessage("The Brand is Mandatory.");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("Error with the value fo the Brand.");
            RuleFor(x => x.Teraflops).GreaterThan(0).WithMessage("The {PropertyName} must be greater than 0.");
        }
    }
}
