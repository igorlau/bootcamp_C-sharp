using System;
using System.Collections.Generic;

namespace APP_bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("\t\t\tOlá! Bem vindo ao DIO Bank");
            Console.WriteLine("===================================================================");

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarContas();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "2":
                        InserirConta();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "3":
                        Transferir();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "4":
                        Sacar();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "5":
                        Depositar();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida");
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.Write("Obrigado por utilizar nossos serviços!");
            Console.WriteLine();
            
        }

        

        private static void ListarContas()
        {
            if (listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.WriteLine("Contas cadastradas:");
            Console.WriteLine("id |\t Nome \t\t|\t Tipo da Conta \t\t|\t Saldo \t\t|\t Crédito");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} |\t ", i);
                Console.Write(conta);
                Console.WriteLine("");
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Cadastro de nova conta\n");

            Console.Write("Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("\nTipo da Conta (1- Física | 2- Jurídica): ");
            string stringTipoConta = Console.ReadLine();
            int entradaTipoConta;
            while(!int.TryParse(stringTipoConta, out entradaTipoConta)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringTipoConta = Console.ReadLine();
            }

            Console.Write("\nDigite o saldo inicial: R$ ");
            string stringSaldo = Console.ReadLine();
            double entradaSaldo;
            while(!double.TryParse(stringSaldo, out entradaSaldo)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringSaldo = Console.ReadLine();
            }
            if(entradaSaldo < 0){
                Console.WriteLine("Valor de saldo negativo, retornando ao menu principal");
                return;
            }

            Console.Write("\nDigite o crédito: R$ ");
            string stringCredito = Console.ReadLine();
            double entradaCredito;
            while(!double.TryParse(stringCredito, out entradaCredito)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringCredito = Console.ReadLine();
            }

            if(entradaCredito < 0){
                Console.WriteLine("Valor de crédito negativo, retornando ao menu principal");
                return;
            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            
            listaContas.Add(novaConta);
        }

        private static void Transferir()
        {
            ListarContas();

            Console.Write("\n# da conta de origem: ");
            string stringOrigem = Console.ReadLine();
            int indiceContaOrigem;
            while(!int.TryParse(stringOrigem, out indiceContaOrigem)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringOrigem = Console.ReadLine();
            }
            if(indiceContaOrigem > listaContas.Count){
                Console.WriteLine("O número da conta não existe");
                return;
            }

            Console.Write("# da conta de destino: ");
            string stringDestino = Console.ReadLine();
            int indiceContaDestinho;
            while(!int.TryParse(stringDestino, out indiceContaDestinho)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringDestino = Console.ReadLine();
            }
            if(indiceContaDestinho > listaContas.Count){
                Console.WriteLine("O número da conta não existe");
                return;
            }

            Console.Write("\nValor a ser transferido: R$ ");
            string stringValor = Console.ReadLine();
            double valorTransferencia;
            while(!double.TryParse(stringValor, out valorTransferencia)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringDestino = Console.ReadLine();
            }
            if(valorTransferencia < 0){
                Console.WriteLine("Valor a ser transferido não pode ser negativo, retornando ao menu principal");
                return;
            }

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestinho]);
        }

        private static void Sacar()
        {
            ListarContas();

            Console.Write("\n# da conta: ");
            string stringConta = Console.ReadLine();
            int indiceConta;
            while(!int.TryParse(stringConta, out indiceConta)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringConta = Console.ReadLine();
            }
            if(indiceConta > listaContas.Count){
                Console.WriteLine("O número da conta não existe");
                return;
            }

            Console.Write("\nValor a ser sacado: R$ ");
            string stringSaque = Console.ReadLine();
            double valorSaque;
            while(!double.TryParse(stringSaque, out valorSaque)){
                Console.WriteLine("\nDigite um valor válida!");
                stringSaque = Console.ReadLine();
            }
            if(valorSaque < 0){
                Console.WriteLine("Valor a ser transferido não pode ser negativo, retornando ao menu principal");
                return;
            }

            listaContas[indiceConta].Sacar(valorSaque);
        }
        
        private static void Depositar()
        {
            ListarContas();

            Console.Write("\n# da conta a ser depositada: ");
            string stringConta = Console.ReadLine();
            int indiceConta;
            while(!int.TryParse(stringConta, out indiceConta)){
                Console.WriteLine("\nDigite uma opção válida!");
                stringConta = Console.ReadLine();
            }
            if(indiceConta > listaContas.Count){
                Console.WriteLine("O número da conta não existe");
                return;
            }

            Console.Write("\nValor a ser depositado: R$ ");
            string stringDeposito = Console.ReadLine();
            double valorDeposito;
            while(!double.TryParse(stringDeposito, out valorDeposito)){
                Console.WriteLine("\nDigite um valor válida!");
                stringDeposito = Console.ReadLine();
            }
            if(valorDeposito < 0){
                Console.WriteLine("Valor a ser transferido não pode ser negativo, retornando ao menu principal");
                return;
            }

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\t\t\tMenu Principal");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\nInforme a opção desejada:\n");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("\nC - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
