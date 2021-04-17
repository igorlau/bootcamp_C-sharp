using System;

namespace Classes_Objetos.Heranca
{
    public class Ponto3D : Ponto //Herda da classe 'Ponto' classes Public, Protected e Internal
    {
        public int z;

        //Construtor
        public Ponto3D(int x, int y, int z) : base(x,y)
        {
            this.z = z;
            CalculaDistacia();
        }

        
        public static void Calcular()
        {
            //Faz alguma coisa...
        }

        //Sobrescreve o metodo CalcularDistancia3
        public override void CalculaDistancia3()
        {
            //Faz alguma coisa...
            base.CalculaDistancia3();
        }

    }
}