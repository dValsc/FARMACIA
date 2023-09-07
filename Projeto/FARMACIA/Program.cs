using FARMACIA.Controller;
using FARMACIA.Model;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FARMACIA
{
    internal class Program
    {
        private static ConsoleKeyInfo ConsoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao =0;
            int id, tipo;
            string? nome, generico, fragancia;
            decimal preco;

        ProdutoController produto = new ();

            while (opcao != 6)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("******************************************************");
                Console.WriteLine("                                                      ");
                Console.WriteLine("                        FARMÁCIA                      ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("******************************************************");
                Console.WriteLine("                                                      ");
                Console.WriteLine("                 1 - Criar Produto                    ");
                Console.WriteLine("                 2 - Listar todos os Produtos         ");
                Console.WriteLine("                 3 - Consultar Produto por ID         ");
                Console.WriteLine("                 4 - Atualizar Produto                ");
                Console.WriteLine("                 5 - Deletar Produto                  ");
                Console.WriteLine("                 6 - Sair                             ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("******************************************************");
                Console.WriteLine("Entre com a opção desejada:                           ");
                Console.WriteLine("                                                      ");
                Console.ResetColor();


                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite uma valor inteiro entre 1 e 6");
                    opcao = 0;
                    Console.ResetColor();
                }

                switch (opcao)
                {
                    case 1:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Criar Produto\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o id do Produto: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Nome do Produto: ");
                        nome = Console.ReadLine();

                        nome ??= string.Empty;

                        Console.WriteLine("Digite o preço do Produto: ");
                        preco = Convert.ToDecimal(Console.ReadLine());

                        do
                        {
                            Console.WriteLine("Digite o Tipo do Produto: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                       
                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o medicamento: ");
                                generico = Console.ReadLine();

                                produto.CriarProduto(new Medicamento(id, nome, tipo, preco, generico));
                                break;
                            case 2:
                                Console.WriteLine("Digite a fragancia: ");
                                fragancia = Console.ReadLine();

                                produto.CriarProduto(new Cosmetico(id, nome, tipo, preco, fragancia));
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Listar todos os Produtos\n\n");
                        Console.ResetColor();

                        produto.ListarTodosProdutos();

                        KeyPress();
                        break;
                    case 3:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Consultar Produto por ID\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o ID do Produto: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        produto.ConsultarProdutoID(id);

                        KeyPress();
                        break;
                    case 4:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Atualizar Produto\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o id do Produto: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        var produtox = produto.BuscarNaCollection(id);

                        if (produtox is not null)
                        {
                            Console.WriteLine("Digite o Nome do Produto: ");
                            nome = Console.ReadLine();

                            nome ??= string.Empty;

                            Console.WriteLine("Digite o preço do Produto: ");
                            preco = Convert.ToDecimal(Console.ReadLine());

                            tipo = produtox.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o medicamento: ");
                                    generico = Console.ReadLine();

                                    produto.AtualizarProduto(new Medicamento(id, nome, tipo, preco, generico));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite a fragancia: ");
                                    fragancia = Console.ReadLine();

                                    produto.AtualizarProduto(new Cosmetico(id, nome, tipo, preco, fragancia));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta numero {id} não foi encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Deletar Produto\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o ID do Produto: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        produto.DeletarProduto(id);

                        KeyPress();
                        break;

                    case 6:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nAgradecemos a preferência!");
                        Sobre();
                        Console.ResetColor();
                        System.Environment.Exit(0);
                        break;

                    default:

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                }
            }

            static void Sobre()
            {
                Console.WriteLine("\n*********************************************************");
                Console.WriteLine("Projeto Desenvolvido por: Valéria Carvalho");
                Console.WriteLine("E-mail: valeria.dcarvalho@hotmail.com");
                Console.WriteLine("github.com/dValsc");
                Console.WriteLine("*********************************************************");
            }

            static void KeyPress()
            {
                do
                {
                    Console.Write("\nPressione Enter para Continuar...");
                    ConsoleKeyInfo = Console.ReadKey();
                } while (ConsoleKeyInfo.Key != ConsoleKey.Enter);
            }

        }
    }
}