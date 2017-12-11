namespace TesteDesingPatternsTemplateMethod {
    public class ImpostoINSS : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}