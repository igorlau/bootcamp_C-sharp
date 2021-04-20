using System; 

namespace Consumo_Medio_Automovel
{
    class Program {

    static void Main(string[] args) { 

            int distancia = 0;
            double combustivelGasto = 0.00;
            double consumoMedio = 0.00;
            
            distancia = Convert.ToInt32(Console.ReadLine());
            combustivelGasto = Convert.ToDouble(Console.ReadLine());
        
            consumoMedio = distancia/combustivelGasto;
            
            Console.WriteLine("{0:0.000} km/l", consumoMedio);

    }

    }
}
