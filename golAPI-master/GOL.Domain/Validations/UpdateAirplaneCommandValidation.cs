using FluentValidation;
using GOL.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Validations
{
    public class UpdateAirplaneCommandValidation : AbstractValidator<UpdateAirplaneCommand>
    {
        public UpdateAirplaneCommandValidation()
        {
            RuleFor(x => x.Airplane.Modelo).NotNull().WithMessage("Modelo cannot be null");
        }
    }
}
