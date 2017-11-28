namespace TesteDesingPatternsChainOfResponsability {
    public class ImpostoICMS : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
}