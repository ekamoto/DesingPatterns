namespace TesteDesingPatternsTemplateMethod
{
    public abstract class TemplateMethodImposto : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if(CondicaoMaximaTaxacao(orcamento))
            {
                return MaximaTaxacao(orcamento);
            }
            return MinimaTaxacao(orcamento);
        }

        public abstract double MinimaTaxacao(Orcamento orcamento);
        public abstract double MaximaTaxacao(Orcamento orcamento);
        public abstract bool CondicaoMaximaTaxacao(Orcamento orcamento);
    }
}