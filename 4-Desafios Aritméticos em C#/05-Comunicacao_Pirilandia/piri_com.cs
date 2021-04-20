using System;

namespace _05_Comunicacao_Pirilandia
{
    class piri_com {

    static void Main(string[] args) { 

          string n = Console.ReadLine();
          
          char[] charArray = n.ToCharArray();
          Array.Reverse(charArray);
          
          string v = new string(charArray);
          Console.WriteLine(v);

    }

}
}
