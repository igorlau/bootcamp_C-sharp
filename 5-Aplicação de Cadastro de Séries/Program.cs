using System;

namespace Cadastro_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("\t\t\tOlá! Bem vindo ao DIO Séries");
            Console.WriteLine("===================================================================");

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSeries();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "2":
                        InserirSerie();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "3":
                        AtualizarSerie();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "4":
                        ExcluirSerie();
                        Console.Write("\nPara continuar pressione: [enter]\n");
		                Console.ReadLine();
                        break;
                    case "5":
                        VisualizarSerie();
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

        private static void ListarSeries()
        {
            Console.WriteLine("Séries cadastradas: ");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }


            Console.WriteLine("________________________________");
            Console.WriteLine("ID    |   Série");
            Console.WriteLine("------|-------------------------");

            foreach (var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#{0,2}   |   {1} {2}", 
                                    serie.retornaId(), serie.retornaTitulo(), 
                                    (excluido ? " - *Excluída*" : ""));
                Console.WriteLine("------|-------------------------");
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nCADASTRO DE NOVA SÉRIE:");

            // TITULO
            Console.Write("\n\tTítulo: ");
            string entradaTitulo = Console.ReadLine();

            // GENERO
            string stringGenero = ObterGenero();
            if(stringGenero == "X"){
                Console.WriteLine("\nRetornando ao Menu Principal\n");
                return;
            }
            int entradaGenero = int.Parse(stringGenero);
            
            // ANO
            Console.Write("\n\tAno de início da série: ");
            string strAno = Console.ReadLine();
            int entradaAno;
            while(!int.TryParse(strAno, out entradaAno)){
                Console.WriteLine("\nDigite uma opção válida!");
                strAno = Console.ReadLine();
            }

            // DESCRICAO
            Console.Write("\n\tDescrição da série: ");
            string entradaDescricao = Console.ReadLine();

            // CADASTRO
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            // ID DA SERIE A SER ATUALIZADA
            string stringID = ObterIDSerie();
            if(stringID == "X"){
                Console.WriteLine("\nRetornando ao Menu Principal\n");
                return;
            }
            int serieID = int.Parse(stringID);

            // SELECAO DA SERIE
            var lista = repositorio.Lista();
            var serie = lista[serieID];
            
            // SELECAO DA ATUALIZACAO
            Console.WriteLine("\nATUALIZANDO SÉRIE:   #{0}- {1}", serie.retornaId(), serie.retornaTitulo());
            Console.WriteLine("\t 1- Atualizar Título");
            Console.WriteLine("\t 2- Atualizar Gênero");
            Console.WriteLine("\t 3- Atualizar Ano de Início");
            Console.WriteLine("\t 4- Atualizar Descrição");
            Console.WriteLine("\t 5- Atualizar Tudo");

            string index = Console.ReadLine();

            string attTitulo = "", attDescricao = "";
            int attGenero = 0, attAno = 0;

            switch(index){ 
                case "1": //TITULO
                    Console.Write("\n\tTítulo: ");
                    attTitulo = Console.ReadLine();

                    attGenero = serie.retornaGenero();
                    attAno = serie.retornaAno();
                    attDescricao = serie.retornaDescricao();
                    break;

                case "2": //GENERO
                    attTitulo = serie.retornaTitulo();

                    string stringGenero = ObterGenero();
                    if(stringGenero == "X"){
                        Console.WriteLine("\nRetornando ao Menu Principal\n");
                        return;
                    }
                    attGenero = int.Parse(stringGenero);

                    attAno = serie.retornaAno();
                    attDescricao = serie.retornaDescricao();
                    break;
                
                case "3": //ANO
                    attTitulo = serie.retornaTitulo();
                    attGenero = serie.retornaGenero();

                    Console.Write("\n\tAno de início da série: ");
                    string strAno = Console.ReadLine();
                    while(!int.TryParse(strAno, out attAno)){
                        Console.WriteLine("\nDigite uma opção válida!");
                        strAno = Console.ReadLine();
                    }

                    attDescricao = serie.retornaDescricao();
                    break;

                case "4": //DESCRICAO
                    attTitulo = serie.retornaTitulo();
                    attGenero = serie.retornaGenero();
                    attAno = serie.retornaAno();

                    Console.Write("\n\tDescrição: ");
                    attDescricao = Console.ReadLine();
                    break;

                case "5": //TUDO
                    // TITULO
                    Console.Write("\n\tTítulo: ");
                    attTitulo = Console.ReadLine();

                    // GENERO
                    stringGenero = ObterGenero();
                    if(stringGenero == "X"){
                        Console.WriteLine("\nRetornando ao Menu Principal\n");
                        return;
                    }
                    attGenero = int.Parse(stringGenero);

                    // ANO
                    Console.Write("\n\tAno de início da série: ");
                    strAno = Console.ReadLine();
                    while(!int.TryParse(strAno, out attAno)){
                        Console.WriteLine("\nDigite uma opção válida!");
                        strAno = Console.ReadLine();
                    }

                    // DESCRICAO
                    Console.Write("\n\tDescrição da série: ");
                    attDescricao = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opção Inválida: Retornando ao Menu Principal");
                    break;
            }

            //ATUALIZACAO
            Serie atualizaSerie = new Serie(id: serieID,
                                        genero: (Genero)attGenero,
                                        titulo: attTitulo,
                                        ano: attAno,
                                        descricao: attDescricao);
            
            repositorio.Atualiza(serieID, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            // ID DA SERIE A SER ATUALIZADA
            string stringID = ObterIDSerie();
            if(stringID == "X"){
                Console.WriteLine("\nRetornando ao Menu Principal\n");
                return;
            }
            int serieID = int.Parse(stringID);

            // CONFIRMACAO DA EXCLUSAO
            Console.WriteLine("Deseja mesmo excluir a série: ");
            var serie = repositorio.RetornaPorId(serieID);
            Console.WriteLine(serie);
            Console.Write("\n (Y/N): ");
            string confirmacao = Console.ReadLine();
            if(confirmacao.ToUpper() == "Y"){
                repositorio.Exclui(serieID);
                Console.WriteLine("================");
                Console.WriteLine("Série excluída||");
                Console.WriteLine("================");
            }
            else{
                return;
            }
            
        }

        private static void VisualizarSerie()
        {
            ListarSeries();

            // ID DA SERIE A SER VISUALIZADA
            Console.Write("\nID da série a ser visualizada: ");
            string strID = Console.ReadLine();
            int serieID;
            while(!int.TryParse(strID, out serieID)){
                Console.WriteLine("\nDigite um ID válido (ou 'X' para sair)");
                strID = Console.ReadLine();
                if(strID.ToUpper() == "X"){
                    Console.WriteLine("Retornando ao Menu Principal");
                    return;
                }
            }

            // DISPLAY
            var serie = repositorio.RetornaPorId(serieID);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\t\t\tMenu Principal");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\nInforme a opção desejada:\n");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("\nC - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterIDSerie()
        {
            ListarSeries();
            Console.Write("\nID da série: ");
            string strID = Console.ReadLine();
            int serieID;
            while(!int.TryParse(strID, out serieID)){
                Console.WriteLine("\nDigite um ID válido (ou 'X' para sair)");
                strID = Console.ReadLine();
                if(strID.ToUpper() == "X"){
                    strID = "X";
                    break;
                }
            }

            if(serieID > repositorio.ProximoId()){
                Console.WriteLine("ID inválido");
                strID = "X";
            }

            return strID;
        }

        private static string ObterGenero()
        {
            Console.WriteLine("\nOpções de Gênero: ");
            Console.WriteLine("________________________");
            Console.WriteLine("ID   |   Genero");
            Console.WriteLine("-----|------------------");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0,2}   |   {1}", i, Enum.GetName(typeof(Genero), i));
                Console.WriteLine("-----|------------------");
            }

            Console.Write("\n\tGênero: ");
            string strGenero = Console.ReadLine();
            int entradaGenero;
            while(!int.TryParse(strGenero, out entradaGenero)){
                Console.WriteLine("\nDigite uma opção de gênero válida (ou 'X' para sair)");
                strGenero = Console.ReadLine();
                if(strGenero.ToUpper() == "X"){
                    break;
                }
            }

            if(!Enum.IsDefined(typeof(Genero), entradaGenero))
            {
                Console.WriteLine("Gênero Inválido!");
                strGenero = "X";
            }

            return strGenero;
        }

    }
}
