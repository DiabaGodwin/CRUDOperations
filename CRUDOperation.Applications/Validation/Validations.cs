using CRUDOperation.Application.Commands.Request;
using CRUDOperation.Application.Dtos;
using CRUDOperation.Application.Repository;
using CRUDOperations.Infrastructure.Dtos;
using CRUDOperations.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Validation
{
    public  class AddBrandValidator : AbstractValidator<BrandCreateDto>
    {
        public AddBrandValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Please select name to proceed")
                .NotNull().WithMessage("Please select name to proceed");
        }

    }


    public class UpdateBrandValidator : AbstractValidator<BrandUpdateDto>
    {
        public UpdateBrandValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Please select name to proceed")
                .NotNull().WithMessage("Please select name to proceed");
        }

    }
}
