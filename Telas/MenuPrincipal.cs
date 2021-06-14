using System;

namespace DIO.Series.Telas
{
    public class MenuPrincipal
    {
        static SerieRepositorio RepositorioSeries = new SerieRepositorio();
        static FilmeRepositorio RepositorioFilmes = new FilmeRepositorio();
        public void Menu()
        {
            Console.WriteLine("Menu:");
            Console.Write("Filme(F) - Serie(S) - Sair(X): ");
            string opcao = Console.ReadLine();
            if (opcao.ToUpper() == "S") MenuSerie();
            else if (opcao.ToUpper() == "F") MenuFilme();
            else if (opcao.ToUpper() == "X")
            {
                System.Console.WriteLine("Obrigrado e até a proxima.");
                Console.ReadLine();
            }
            else System.Console.WriteLine("Opção invalida. Digite 'F' para filme ou 'S' para série.");
        }

        private string ObterOpcaoDoUsuarioFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!!!");

            Console.WriteLine("-----------Menu-----------");
            Console.WriteLine("1- Lista de Filmes.");
            Console.WriteLine("2- Inserir nova Filme.");
            Console.WriteLine("3- Atualizar Filme.");
            Console.WriteLine("4- Excluir Filme.");
            Console.WriteLine("5- Visualizar Filmes.");
            Console.WriteLine("V- Voltar ao menu principal.");
            Console.WriteLine();

            Console.Write("Informe a opcao desejada: ");
            string opcaoUsusario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsusario;
        }
        private void MenuFilme()
        {
            string opcaoUsusarioFilmes = ObterOpcaoDoUsuarioFilmes();

            while (opcaoUsusarioFilmes.ToUpper() != "V")
            {
                switch (opcaoUsusarioFilmes)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExclurFilme();
                        break;
                    case "5":
                        VisualizarFilmes();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsusarioFilmes = ObterOpcaoDoUsuarioFilmes();
            }
            Console.Clear();
            Menu();

        }
        private void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes.");

            var lista = RepositorioFilmes.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var Filmes in lista)
            {
                var excluido = Filmes.retotnaExcluido();

                System.Console.WriteLine("#ID {0} - {1} {2}",
                                         Filmes.retotnaId(),
                                         Filmes.retotnaTitulo(),
                                         (excluido ? "-Excluido-" : "")
                                         );
            }
            string menu = "V";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu:");
                menu = Console.ReadLine();
            }
            Console.Clear();
        }
        private void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme.");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da filme: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o ano de início da filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da filme: ");
            string entradaDescricao = (Console.ReadLine());

            Filmes novoFilme = new Filmes(
            id: RepositorioSeries.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
            RepositorioFilmes.Insere(novoFilme);
            Console.Clear();
        }
        private void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o ano de início da filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da filme: ");
            string entradaDescricao = (Console.ReadLine());

            Filmes AtualizaSerie = new Filmes(id: indiceFilme,
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);
            RepositorioFilmes.Atualiza(indiceFilme, AtualizaSerie);
            Console.Clear();
        }
        private void ExclurFilme()
        {
            Console.Write("Digite o id da filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            RepositorioSeries.Exclui(indiceFilme);

            string menu = "V";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu: ");
                menu = Console.ReadLine();
            }
            Console.Clear();
        }
        private void VisualizarFilmes()
        {
            Console.Write("Digite o id da filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = RepositorioFilmes.RetornaPorId(indiceFilme);
            Console.WriteLine(filme);

            string menu = "";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu: ");
                menu = Console.ReadLine();
            }
            Console.Clear();
        }




        //Series--------------------------------------------------------------------------------------
        private static string ObterOpcaoDoUsuarioSerie()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");

            Console.WriteLine("-----------Menu-----------");
            Console.WriteLine("1- Lista de Séries.");
            Console.WriteLine("2- Inserir nova série.");
            Console.WriteLine("3- Atualizar série.");
            Console.WriteLine("4- Excluir série.");
            Console.WriteLine("5- Visualizar série.");
            Console.WriteLine("V- Voltar ao menu principal.");
            Console.WriteLine();

            Console.Write("Informe a opcao desejada: ");
            string opcaoUsusario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsusario;

        }
        private void MenuSerie()
        {
            string opcaoUsusarioSerie = ObterOpcaoDoUsuarioSerie();

            while (opcaoUsusarioSerie.ToUpper() != "V")
            {
                switch (opcaoUsusarioSerie)
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
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsusarioSerie = ObterOpcaoDoUsuarioSerie();
            }
            Console.Clear();
            Menu();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries.");

            var lista = RepositorioSeries.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retotnaExcluido();

                System.Console.WriteLine("#ID {0} - {1} {2}",
                                         serie.retotnaId(),
                                         serie.retotnaTitulo(),
                                         (excluido ? "-Excluido-" : "")
                                         );
            }
            string menu = "V";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu:");
                menu = Console.ReadLine();
            }
            Console.Clear();

        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série.");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o total de temporadas produzidas da série: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = (Console.ReadLine());

            Series novaSerie = new Series(
            id: RepositorioSeries.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            temporadas: entradaTemporada,
            ano: entradaAno,
            descricao: entradaDescricao);
            RepositorioSeries.Insere(novaSerie);
            Console.Clear();
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = (Console.ReadLine());

            Console.Write("Digite o total de temporadas produzidas da série: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = (Console.ReadLine());

            Series AtualizaSerie = new Series(id: indiceSerie,
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           temporadas: entradaTemporada,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);
            RepositorioSeries.Atualiza(indiceSerie, AtualizaSerie);
            Console.Clear();
        }
        private static void ExclurSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            RepositorioSeries.Exclui(indiceSerie);

            string menu = "V";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu: ");
                menu = Console.ReadLine();
            }
            Console.Clear();
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = RepositorioSeries.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);

            string menu = "";
            while (menu.ToUpper() != "M")
            {
                Console.Write("Digite 'M' para retornar ao menu: ");
                menu = Console.ReadLine();
            }
            Console.Clear();
        }
    }
}