using System;

namespace _04_Tempo_de_Evento
{

class event_time {

    static void Main(string[] args) { 
        int diaInicio, horaInicio, minutoInicio, segundoInicio;
        int diaTermino, horaTermino, minutoTermino, segundoTermino;

        string[] dadosInicio = Console.ReadLine().Split();
        diaInicio = Convert.ToInt32(dadosInicio[1]);

        string[] momentoInicio = Console.ReadLine().Split();
        horaInicio = Convert.ToInt32(momentoInicio[0]);
        minutoInicio = Convert.ToInt32(momentoInicio[2]);
        segundoInicio = Convert.ToInt32(momentoInicio[4]);

        string[] dadosTermino = Console.ReadLine().Split();
        diaTermino = Convert.ToInt32(dadosTermino[1]);

        string[] momentoTermino = Console.ReadLine().Split();
        horaTermino = Convert.ToInt32(momentoTermino[0]);
        minutoTermino = Convert.ToInt32(momentoTermino[2]);
        segundoTermino = Convert.ToInt32(momentoTermino[4]);
           
        int Segundos  = segundoTermino - segundoInicio;
        int Minutos   = minutoTermino - minutoInicio;
        int Horas     = horaTermino - horaInicio;
        int Dias      = diaTermino - diaInicio;
            
        if(Segundos<0){
            Minutos -= 1;
            Segundos += 60; 
        }
            
        if(Minutos<0){
            Horas -= 1;
            Minutos += 60;
        }
            
        if(Horas<0){
            Dias -= 1;
            Horas += 24;
        }

        Console.WriteLine("{0} dia(s)\n {1} hora(s)\n {2} minuto(s)\n {3} segundo(s)", Dias, Horas, Minutos, Segundos);


    }

}
}