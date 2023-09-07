using FARMACIA.Model;
using FARMACIA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FARMACIA.Controller
{
    public class ProdutoController : IProdutoRepository
    {
        private readonly List<Produto> listaProduto = new();
        int numero = 0;

        public void AtualizarProduto(Produto produto)
        {
            var buscaProduto = BuscarNaCollection(produto.GetId());

            if (buscaProduto is not null)
            {
                var index = listaProduto.IndexOf(buscaProduto);

                listaProduto[index] = produto;

                Console.WriteLine($"O produto numero {produto.GetId()} foi atualizado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O produto numero {produto.GetId()} não foi encontrado!");
                Console.ResetColor();
            }
        }
        public void ConsultarProdutoID(int id)
        {
            var produto = BuscarNaCollection(id);

            if (produto is not null)
                produto.visualizar();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {id} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void CriarProduto(Produto produto)
        {
            listaProduto.Add(produto);
            Console.WriteLine($"Produto número {produto.GetId()} foi criado com sucesso!");
        }

        public void DeletarProduto(int id)
        {
            var produto = BuscarNaCollection(id);

            if (produto is not null)
            {
                if (listaProduto.Remove(produto) == true)
                    Console.WriteLine($"Produto número {id} foi apagado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Produto numero {id} não foi encontrado!");
                Console.ResetColor();
            }
        }

        public void ListarTodosProdutos()
        {
            foreach (var produto in listaProduto)
            {
                produto.visualizar();
            }
        }

        public Produto? BuscarNaCollection(int id)
        {
            foreach (var produto in listaProduto)
            {
                if (produto.GetId() == id)
                    return produto;
            }

            return null;
        }



    }
}
