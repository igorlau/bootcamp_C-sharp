using System;
using Api.Enums;

namespace Api.Models
{
    public class InfectadoDto
    {
        public int ID {get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}