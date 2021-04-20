using System;

namespace Aumento_de_Salário
{
    using System; 

class Program {

    static void Main(string[] args) { 

            double salario = 0.00;
            double reajuste = 0.00;
            double novoSalario = 0.00;
            double percentual = 0.00;
            
            salario = Convert.ToDouble(Console.ReadLine().Replace(",","."));
            
            if(salario < 0.00){
              return;
            }
            
            else if(salario <= 400.00){
              percentual = 0.15;
            }
            
            else if(salario > 400.00 && salario <= 800.00){
              percentual = 0.12;
            }
            
            else if(salario > 800.00 && salario <= 1200.00){
              percentual = 0.10;
            }
            
            else if(salario > 1200.00 && salario <= 2000.00){
              percentual = 0.07;
            }

            else if(salario >= 2000.00){
              percentual = 0.04;
            }
            
            else{
              return;
            }
            
            reajuste = salario * percentual;
            novoSalario = salario + reajuste;
            
                
            Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
            Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
            Console.WriteLine("Em percentual: {0} %", percentual*100);


    }

}

}
