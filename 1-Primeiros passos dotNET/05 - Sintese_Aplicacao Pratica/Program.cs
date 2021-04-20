using System;

namespace Sintese_Aplicacao_Pratica
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<Aluno> alunos = new System.Collections.Generic.List<Aluno>();
            var indiceAluno = 0;

            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //Adicionar aluno
                        Aluno aluno = new Aluno();

                        Console.WriteLine("Informe o nome do aluno:"); 
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        
                        alunos.Add(aluno);
                        indiceAluno++;
                        break;

                    case "2":
                        //Listar alunos
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} \t\t NOTA: {a.Nota}");
                            }
                            
                        }
                        break;

                    case "3":
                        //Calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i<alunos.Count; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var media = notaTotal/nrAlunos;
                        
                        
                        Conceito conceitoGeral;
                        if(media < 6)
                        {
                            conceitoGeral = Conceito.F;
                        }
                        else if(media >= 6 & media < 7)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(media >= 7 & media < 8)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(media >= 7 & media < 9)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        
                        Console.WriteLine($"MÉDIA GERAL: {media} \t\t CONCEITO GERAL: {conceitoGeral}");

                        break;
                    default:
                        Console.WriteLine("\nDigite uma opção válida\n");
                        break;
                        //throw new ArgumentOutOfRangeException("Digite uma opção válida");
                }

                opcaoUsuario = obterOpcaoUsuario();
            }



        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}
