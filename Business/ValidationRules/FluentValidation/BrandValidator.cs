using Business.Constants;
using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ErrorNullData);
        }
        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
