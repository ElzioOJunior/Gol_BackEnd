using GOL.Commom.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Entities.Airplane
{
    public class Airplane : BaseEntity
    {
        public Airplane(string codigoAviao, string modelo, int qtdPassageiros )
        {
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataCriacao = DateTime.Now;
        }

        public Airplane(Guid id, string codigoAviao, string modelo, int qtdPassageiros)
        {
            Id = id;
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataCriacao = DateTime.Now;
        }

        public string CodigoAviao { get; private set; }
        public string Modelo { get; private set; }
        public int QtdPassageiros { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
