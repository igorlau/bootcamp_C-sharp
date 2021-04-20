using System;

namespace Classes_Objetos.Metodos
{
    public class Ref
    {
        //Ref faz com que as modificacoes na variavel dentro do metodo interfiram no seu valor fora do metodo
        static void Inverter(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void Inverter()
        {
            int i = 1, j = 2;
            Inverter(ref i, ref j);
            System.Console.WriteLine($"{i} {j}"); 
            // Escreve "2 1", sem o ref escreveria "1 2"
        }
    }
}
