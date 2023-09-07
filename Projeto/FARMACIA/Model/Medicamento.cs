using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FARMACIA.Model
{
    public class Medicamento : Produto
    {
        private string generico;
        public Medicamento(int id, string nome, int tipo, decimal preco, string generico) : base(id, nome, tipo, preco)
        {
            this.generico = generico;
        }

        public string GetGenerico() { return this.generico; }
        public void SetGenerico (string generico) { this.generico = generico; }

        public override void visualizar()
        {
            base.visualizar();
            Console.WriteLine("Genérico:" + this.generico);
        }
    }
}
