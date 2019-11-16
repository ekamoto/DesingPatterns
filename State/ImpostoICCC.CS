namespace TesteDesingPatternsState {

    public class ImpostoICCC : Imposto
    {
        public ImpostoICCC(Imposto outroImposto) : base(outroImposto)
        {
        }

        public ImpostoICCC() : base()
        {
        }

        public override double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05 + CalculaOutroImposto(orcamento);
            if (orcamento.Valor >= 1000 && orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07 + CalculaOutroImposto(orcamento);
            else
                return (orcamento.Valor * 0.08) + 30 + CalculaOutroImposto(orcamento);
        }
    }
}