namespace TesteDesingPatternsTemplateMethod {

    public class ImpostoICPP : Imposto
    {
        public ImpostoICPP()
        {
        }

        public double Calcular(Orcamento orcamento)
        {
            if(orcamento.Valor > 200)
            {
                return orcamento.Valor * 0.96;
            }
            return orcamento.Valor * 0.5;
        }
    }
}

