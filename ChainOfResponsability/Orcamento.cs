namespace TesteDesingPatternsChainOfResponsability {
    public class Orcamento {

        public double Valor { get; set; }

        public IList<Item> itens { get; set; }

        public Orcamento(double Valor)
        {
            this.Valor = Valor;
        }
    }
}