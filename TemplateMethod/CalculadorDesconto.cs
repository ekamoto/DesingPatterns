namespace TesteDesingPatternsTemplateMethod
{
    public class CalculadorDesconto {

        public CalculadorDesconto()
        {
            
        }

        public double Calcular(Orcamento orcamento, Desconto desconto)
        {
            return desconto.Calcular(orcamento);
        }
    }
}