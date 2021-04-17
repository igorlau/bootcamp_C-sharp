using System;
using Classes_Objetos.Heranca;

namespace Classes_Objetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Ponto p1 = new Ponto(10,20);

            Ponto3D p2 = new Ponto3D(10,20,30);

            //Nao tem acesso a CalcularDistancia1 e CalcularDistancia2
            p1.CalculaDistancia3();
            //Nao tem acesso a Calcular (estatico => pertence a classe)
            p2.CalculaDistancia3();
            Ponto3D.Calcular();
        }
    }
}
