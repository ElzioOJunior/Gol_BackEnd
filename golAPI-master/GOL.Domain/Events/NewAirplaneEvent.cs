using GOL.Commom.Publisher;
using GOL.Domain.Entities.Airplane;

namespace GOL.Domain.Events
{
    public class NewAirplaneEvent : Event
    {
        public NewAirplaneEvent(Airplane newAirplane)
        {
            Airplane = newAirplane;
        }
        public Airplane Airplane { get; set; }
    }
}
