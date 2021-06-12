using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsusario = ObterOpcaoDoUsuario();

            while (opcaoUsusario.ToUpper() != "X")
            {
                switch (opcaoUsusario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExclurSerie();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                        default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsusario = ObterOpcaoDoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void VisualizarSeries()
        {
            throw new NotImplementedException();
        }

        private static void ExclurSerie()
        {
            throw new NotImplementedException();
        }

        private static void AtualizarSerie()
        {
            throw new NotImplementedException();
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série.");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = (Console.ReadLine());
            
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = (Console.ReadLine());

            Series novaSerie = new Series(
            id: Repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries.");

            var lista = Repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista)
            {
                System.Console.WriteLine("#ID {0} - {1}", serie.retotnaId(), serie.retotnaTitulo());

            }

        }

        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");

            Console.WriteLine("-----------Menu-----------");
            Console.WriteLine("1- Lista de Séries.");
            Console.WriteLine("2- Inserir nova série.");
            Console.WriteLine("3- Atualizar série.");
            Console.WriteLine("4- Excluir série.");
            Console.WriteLine("5- Visualizar série.");
            Console.WriteLine("C- Limpar tela.");
            Console.WriteLine("X- Sair.");
            Console.WriteLine();

            Console.Write("Informe a opcao desejada: ");
            string opcaoUsusario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsusario;

        }
    }
}
