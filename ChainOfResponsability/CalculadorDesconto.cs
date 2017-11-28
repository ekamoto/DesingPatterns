namespace TesteDesingPatternsChainOfResponsability
{
    public class CalculadorDesconto {

        public CalculadorDesconto()
        {
            
        }

        public double Calcular(Orcamento orcamento)
        {
            // Problema...
            if(orcamento.itens.Count > 5)
            {
                return orcamento.Valor * 0.5;               
            } 
            else if(orcamento.Valor > 500)
            {
                return orcamento.Valor * 0.03;               
            }

            return 0;
        }
    }
}