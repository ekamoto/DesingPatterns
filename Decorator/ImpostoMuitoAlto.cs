namespace TesteDesingPatternsDecorator
{
    public class ImpostoMuitoAlto : Imposto
    {
        public ImpostoMuitoAlto()
        {
        }

        public ImpostoMuitoAlto(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.02 + CalculaOutroImposto(orcamento);
        }
    }
}
