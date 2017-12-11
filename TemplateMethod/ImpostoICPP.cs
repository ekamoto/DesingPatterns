namespace TesteDesingPatternsTemplateMethod {

    public class ImpostoICPP : TemplateMethodImposto
    {
        public ImpostoICPP()
        {
        }

        public override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 200;
        }

        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.96;
        }

        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.5;
        }
    }
}

