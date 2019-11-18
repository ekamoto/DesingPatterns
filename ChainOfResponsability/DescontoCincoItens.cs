namespace TesteDesingPatternsChainOfResponsability
{
    public class DescontoCincoItens : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            if(orcamento.itens.Count > 100)
            {
                return orcamento.Valor * 0.5;               
            } 
            return Proximo.Calcular(orcamento);
        }
    }
}