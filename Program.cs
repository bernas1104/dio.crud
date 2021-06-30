using System;

namespace DIO.Crud
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.Id, serie.Titulo);
            }
        }

        private static void InserirSerie()
        {
            int genero;
            string titulo;
            string descricao;
            int ano;

            Console.WriteLine("Genero da série?");
            genero = ObterGeneroSerie();

            Console.WriteLine("Qual o título da série?");
            titulo = Console.ReadLine();

            Console.WriteLine("Qual a descrição da série?");
            descricao = Console.ReadLine();

            Console.WriteLine("Qual o ano da série?");
            ano = Int16.Parse(Console.ReadLine());

            int id = repositorio.ProximoId();

            Serie serie = new Serie(id, (Genero)genero, titulo, descricao, ano);

            repositorio.Insere(serie);

            Console.WriteLine("Série inserida!");
            Console.WriteLine(serie.ToString());
        }

        private static void AtualizarSerie()
        {
            int genero;
            string titulo;
            string descricao;
            int ano;

            Console.WriteLine("Qual ID da série que quer atualizar?");
            int id = Int32.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);

            Console.WriteLine("Novo genero da série?");
            genero = ObterGeneroSerie();

            Console.WriteLine("Qual o novo título da série?");
            titulo = Console.ReadLine();

            Console.WriteLine("Qual a nova descrição da série?");
            descricao = Console.ReadLine();

            Console.WriteLine("Qual o novo ano da série?");
            ano = Int16.Parse(Console.ReadLine());

            serie.Genero = (Genero)genero;
            serie.Titulo = titulo;
            serie.Descricao = descricao;
            serie.Ano = ano;

            repositorio.Atualiza(id, serie);

            Console.WriteLine("Série atualizada!");
            Console.WriteLine(serie.ToString());
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual ID da série que quer excluir?");
            int id = Int32.Parse(Console.ReadLine());

            repositorio.Exclui(id);

            Console.WriteLine("Série excluída!");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Qual ID da série que quer visualizar?");
            int id = Int32.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie.ToString());
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Console");
            Console.WriteLine("X - Encerrar programa");

            string opcao = Console.ReadLine();

            return opcao;
        }

        private static int ObterGeneroSerie()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(
                    "{0} - {1}",
                    i,
                    Enum.GetName(typeof(Genero), i)
                );
            }

            int opcao = Int32.Parse(Console.ReadLine());

            if (opcao < 1 || opcao > 13)
            {
                throw new ArgumentOutOfRangeException();
            }

            return opcao;
        }
    }
}
