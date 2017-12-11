using System.Collections.Generic;

namespace TesteDesingPatternsTemplateMethod {
    public class Orcamento {

        public double Valor { get; set; }

        public IList<Item> itens { get; set; }

        public Orcamento(double Valor)
        {
            this.Valor = Valor;
            itens = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this.itens.Add(item);
        }
    }
}