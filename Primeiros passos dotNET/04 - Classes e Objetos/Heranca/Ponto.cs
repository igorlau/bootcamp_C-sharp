using System;

namespace Classes_Objetos.Heranca
{
    public class Ponto
    {
        public int x, y; //Acessada de qualquer lugar

        private int distancia; //So e acessa neste escopo

        public Ponto (int x, int y) //Construtor
        {
            this.x = x;
            this.y = y;
        }

        protected void CalculaDistacia() //Acessado somente pelos filhos
        {
            //Faz alguma coisa...
            CalculaDistancia2();
        }

        private void CalculaDistancia2() //Acessado somente neste escopo
        {
            //Faz alguma coisa...
        }

        public virtual void CalculaDistancia3() //'virtual' = permite que uma classe filha sobrescreva a sua atuacao
        {
            //Faz alguma coisa...
        }
    }
}