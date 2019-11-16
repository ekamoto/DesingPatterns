namespace TesteDesingPatternsState {
    public abstract class Imposto {

        Imposto OutroImposto { get; set; }

        public Imposto(Imposto outroImposto)
        {
            this.OutroImposto = outroImposto;
        }

        public Imposto()
        {
            this.OutroImposto = null;
        }

        public abstract double Calcular(Orcamento orcamento);

        protected double CalculaOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null)
                return 0;

            return OutroImposto.Calcular(orcamento);
        }

    }
}
