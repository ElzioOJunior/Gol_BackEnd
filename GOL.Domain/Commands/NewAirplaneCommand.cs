using GOL.Commom.Publisher;
using GOL.Domain.DTO;
using GOL.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Commands
{
    public class NewAirplaneCommand : Command
    {
        public NewAirplaneCommand(AirplaneDTO airplane)
        {
            Airplane = airplane;
        }

        public AirplaneDTO Airplane { get;  set; }

        public override bool IsValid()
        {
            return new NewAirplaneCommandValidation().Validate(this).IsValid;
        }
    }
}
