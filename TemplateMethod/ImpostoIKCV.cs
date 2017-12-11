namespace TesteDesingPatternsTemplateMethod
{
    public class ImpostoIKCV : TemplateMethodImposto
    {
        public ImpostoIKCV()
        {

        }

        public override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.itens.Count > 5;
        }

        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 5;
        }

        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 7;
        }
    }
}