using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FARMACIA.Model
{
    public abstract class Produto
    {
        private int id;
        private string nome;
        private int tipo;
        private decimal preco;

        public Produto(int id, string nome, int tipo, decimal preco)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.preco = preco;
        }

        public int GetId() { return id; }
        public void SetId(int id) { this.id = id; }
        public string GetNome() { return nome; }
        public void SetNome (string nome) { this.nome = nome;}
        public int GetTipo() {  return tipo; }
        public void SetTipo (int tipo) {  this.tipo = tipo; }
        public decimal GetPreco() {  return preco; }
        public void SetPreco(decimal preco) { this.preco = preco; }

        public virtual void visualizar ()
        {
            string tipo = string.Empty;

            switch (this.tipo)
            {
                case 1:
                    tipo = "Medicamento";
                    break;
                case 2:
                    tipo = "Cosmético";
                    break;
            }

            Console.WriteLine("********************************************");
            Console.WriteLine("Dados do Produto");
            Console.WriteLine("********************************************");
            Console.WriteLine($"ID Produto: {this.id}");
            Console.WriteLine($"Nome Produto: {this.nome}");
            Console.WriteLine($"Tipo Produto: {tipo}");
            Console.WriteLine($"Preço do Produto: {this.preco}");


        }

    }
}
