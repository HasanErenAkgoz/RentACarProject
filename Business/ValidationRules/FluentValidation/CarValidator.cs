using Business.Constants;
using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarInfo>
    {
        public CarValidator()
        {
            RuleFor(c => c.Plate).MinimumLength(2);
            RuleFor(c => c.Plate).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.MinFindeksScore).LessThan(1900).WithMessage(Messages.maxFindexScore);
            RuleFor(c => c.MinFindeksScore).GreaterThan(0).WithMessage(Messages.minFindexScore);


        }
    }
}