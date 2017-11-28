using System;

namespace TesteDesingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            TesteStrategy();
            TesteChainOfResponsability();
        }

        private static void TesteChainOfResponsability()
        {
            Console.WriteLine("Iniciando Teste Chain of Responsability");

            TesteDesingPatternsChainOfResponsability.Orcamento orcamento = new TesteDesingPatternsChainOfResponsability.Orcamento(900);
            
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 1", 600));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 2", 250));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 3", 50));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 4", 2.50));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 5", 6.90));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 6", 600));

            TesteDesingPatternsChainOfResponsability.CalculadorDesconto calculadorDesconto = new TesteDesingPatternsChainOfResponsability.CalculadorDesconto();

            var valor = calculadorDesconto.Calcular(orcamento);

            Console.WriteLine("Valor:" + valor);

            Console.WriteLine("Fim Teste Chain of Responsability");
        }

        private static void TesteStrategy() {
            Console.WriteLine("Iniciando Teste Strategy");
            TesteDesingPatternsStrategy.Orcamento orcamento = new TesteDesingPatternsStrategy.Orcamento(500);
            TesteDesingPatternsStrategy.CalculaImposto calculadorImposto = new TesteDesingPatternsStrategy.CalculaImposto();

            TesteDesingPatternsStrategy.Imposto impostoINSS = new TesteDesingPatternsStrategy.ImpostoINSS();
            TesteDesingPatternsStrategy.Imposto ImpostoICMS = new TesteDesingPatternsStrategy.ImpostoICMS();
            
            var valor = calculadorImposto.Calcula(orcamento,  impostoINSS);

            Console.WriteLine("Valor Imposto: " + valor);
            Console.WriteLine("Fim Teste Strategy");
        }
    }
}
