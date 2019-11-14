namespace TesteDesingPatternsDecorator {
    public class ImpostoINSS : Imposto
    {
        public ImpostoINSS()
        {
        }

        public ImpostoINSS(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculaOutroImposto(orcamento);
        }
    }
}