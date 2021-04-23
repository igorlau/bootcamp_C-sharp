using System;

namespace Coordenadas_Ponto
{
    class Program {

    static void Main(string[] args) { 

      float x, y;
      
      string[] entrada = Console.ReadLine().Split();
      
      x = float.Parse(entrada[0]);
      y = float.Parse(entrada[1]);
      
      if(x>0) {
        if(y>0) { Console.WriteLine("Q1"); }
        else if(y<0) { Console.WriteLine("Q4"); }
        else { Console.WriteLine("Eixo X"); }
      }
      else if(x<0){
        if(y>0) { Console.WriteLine("Q2"); }
        else if(y<0) { Console.WriteLine("Q3"); }
        else { Console.WriteLine("Eixo X"); }
      }
      else{
        if(y==0) { Console.WriteLine("Origem"); }
        else { Console.WriteLine("Eixo Y"); }
      }
        
    }

}
}
