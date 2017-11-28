namespace TesteDesingPatternsChainOfResponsability
{
    public class SemDesconto: Desconto {

        public SemDesconto()
        {
            
        }

        public Desconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            return 0;
        }
    }

}