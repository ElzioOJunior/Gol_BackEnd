using GOL.Commom.Publisher;
using GOL.Domain.DTO;
using GOL.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Commands
{
    public class UpdateAirplaneCommand : Command
    {
        public UpdateAirplaneCommand(AirplaneDTO airplane)
        {
            Airplane = airplane;
        }

        public AirplaneDTO Airplane { get;  set; }

        public override bool IsValid()
        {
            return new UpdateAirplaneCommandValidation().Validate(this).IsValid;
        }
    }
}
