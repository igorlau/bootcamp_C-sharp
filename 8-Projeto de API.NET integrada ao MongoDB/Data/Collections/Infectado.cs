using System;
using MongoDB.Driver.GeoJsonObjectModel;
using Api.Enums;

namespace Api.Data.Collections
{
    public class Infectado
    {
        public Infectado(int id, DateTime dataNascimento, Sexo sexo, double latitude, double longitude)
        {
            this.ID = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public int ID { get; set;}
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}