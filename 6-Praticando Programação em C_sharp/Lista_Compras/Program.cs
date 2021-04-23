using System;
using System.Collections.Generic;

namespace Lista_Compras{

    class Program {
  
        public static void Main (string[] args) {

            int totalDeCasosDeTeste = int.Parse(Console.ReadLine());
    
            List<string> listaCompras = new List<string>();
    
            for (int i=0; i < totalDeCasosDeTeste; i++){
        
                if(i>100) { return; }
        
                string[] entradas = Console.ReadLine().Split(" ");
        
                for(int item=0; item<entradas.Length; item++){
                    if(item>1000) { return; }
                    if(!listaCompras.Contains(entradas[item])) { listaCompras.Add(entradas[item]); }
                }
        
                listaCompras.Sort();
      
                Console.WriteLine(string.Join(" ",listaCompras));
        
                listaCompras.Clear();
        
            } 
        }
    }
}
