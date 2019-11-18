namespace TesteDesingPatternsChainOfResponsability
{
    public class DescontoValorMaiorQuinhentos : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            if(orcamento.Valor > 2000)
            {
                return orcamento.Valor * 0.03;               
            }
            return Proximo.Calcular(orcamento);
        }   
    }
}