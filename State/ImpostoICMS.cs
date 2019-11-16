namespace TesteDesingPatternsState {
    public class ImpostoICMS : Imposto
    {
        public ImpostoICMS()
        {
        }

        public ImpostoICMS(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
}