using System;

namespace Pink_Cerebro
{
    using System; 

class minhaClasse {

    static void Main(string[] args) { 

        int qtde = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(" ");
        
        int mult2=0, mult3=0, mult4=0, mult5=0;
 
            for (int i=0; i<qtde; i++)
            {
                int number = int.Parse(numbers[i]);
                if(number%2 == 0) { mult2 += 1; }
                if(number%3 == 0) { mult3 += 1; }
                if(number%4 == 0) { mult4 += 1; }
                if(number%5 == 0) { mult5 += 1; }
            }
            
            Console.WriteLine("{0} Multiplo(s) de 2", mult2);
            Console.WriteLine("{0} Multiplo(s) de 3", mult3);
            Console.WriteLine("{0} Multiplo(s) de 4", mult4);
            Console.WriteLine("{0} Multiplo(s) de 5", mult5);
    }
}
}
