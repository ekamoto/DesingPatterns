using System;

namespace TesteDesingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            TesteStrategy();

        }

        static void TesteStrategy() {
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
