using System;

namespace GOL.Domain.DTO
{
    public class AirplaneDTO
    {
        public Guid id { get; set; }
        public string CodigoAviao { get;  set; }
        public string Modelo { get;  set; }
        public int QtdPassageiros { get;  set; }
    }
}
