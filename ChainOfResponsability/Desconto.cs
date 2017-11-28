namespace TesteDesingPatternsChainOfResponsability
{
    public interface Desconto
    {
        double Calcular(Orcamento orcamento);
        Desconto Proximo { get; set; }
    }
}