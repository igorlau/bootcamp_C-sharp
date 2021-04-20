using System;

namespace _01_Media_1
{
    class media_1 {

    static void Main(string[] args) { 

            double a, b, mediaP;

            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            
            mediaP = ((a*3.5) + (b*7.5)) / (3.5 + 7.5);

            Console.WriteLine("MEDIA = {0}\n", mediaP.ToString("0.00000"));

    }

}
}
