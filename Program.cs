using System;
using System.Collections.Generic;

namespace TesteDesingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //TesteStrategy();
            //TesteChainOfResponsability();
            //TesteTemplateMethod();
            //TesteDesingPatternsDecorator();
            //TesteDesingPatternsState();
            //TesteDesingPatternsStateContaPositivaNegativa();
            //TesteDesingPatternsBuilder();
            //TesteDesingPatternsObserver();

            // Outros exemplos de utilização para treinar
            var novosTestes = new NovosExemplosUtilizacaoPatterns();
            novosTestes.executar();

            Console.ReadLine();
        }

        // Lista de comportamento que são disparados após uma determinada ação
        // nesse caso é o constroi nota fiscal
        private static void TesteDesingPatternsObserver()
        {
            var listaAcoes = new List<TesteDesingPatternsObserver.AcaoAposGerarNota>();
            listaAcoes.Add(new TesteDesingPatternsObserver.EnviadorDeEmail());
            listaAcoes.Add(new TesteDesingPatternsObserver.NotaFiscalDao());
            listaAcoes.Add(new TesteDesingPatternsObserver.EnviadorDeSms());
            listaAcoes.Add(new TesteDesingPatternsObserver.Impressora());
            listaAcoes.Add(new TesteDesingPatternsObserver.Multiplicador(300));

            TesteDesingPatternsObserver.NotaFiscalObserver nfBuilder = new TesteDesingPatternsObserver.NotaFiscalObserver(listaAcoes);

            TesteDesingPatternsObserver.ItemDaNota itemDaNotaBuilder1 = new TesteDesingPatternsObserver.ItemDaNotaObserver()
            .ComDescricao("Descrição teste 1")
            .ComValor(1200).Constroi();

            // Depois que você constroi a nota fiscal todos os objetos de acões são notificados
            // as ações esperam a construção do objeto
            TesteDesingPatternsObserver.NotaFiscal notaFiscal= nfBuilder.ParaEmpresa("Shindi")
            .ComCnpj("123.456.789/0001-10")
            .ComItem(itemDaNotaBuilder1)
            .ComObservacoes("entregar nf pessoalmente")
            .NaDataAtual(DateTime.Now)
            .Constroi();

            Console.WriteLine(nfBuilder.RazaoSocial);
            Console.WriteLine(nfBuilder.Cnpj);

            foreach(var item in notaFiscal.Itens)
            {
                Console.WriteLine(item.Valor);    
            }

            Console.WriteLine(notaFiscal.Observacoes);
            Console.WriteLine(notaFiscal.DataDeEmissao);

        }

        // Construir objetos complexos
        private static void TesteDesingPatternsBuilder()
        {
            TesteDesingPatternsBuilder.ItemDaNota itemDaNotaBuilder1 = new TesteDesingPatternsBuilder.ItemDaNotaBuilder()
            .ComDescricao("Descrição teste 1")
            .ComValor(1200).Constroi();

            TesteDesingPatternsBuilder.ItemDaNota itemDaNotaBuilder2 = new TesteDesingPatternsBuilder.ItemDaNotaBuilder()
            .ComDescricao("Descrição teste 2")
            .ComValor(350).Constroi();

            TesteDesingPatternsBuilder.ItemDaNota itemDaNotaBuilder3 = new TesteDesingPatternsBuilder.ItemDaNotaBuilder()
            .ComDescricao("Descrição teste 3")
            .ComValor(670).Constroi();

            TesteDesingPatternsBuilder.NotaFiscal notaFiscalBuilder = new TesteDesingPatternsBuilder.NotaFiscalBuilder().ParaEmpresa("Shindi")
                                    .ComCnpj("123.456.789/0001-10")
                                    .ComItem(itemDaNotaBuilder1)
                                    .ComItem(itemDaNotaBuilder2)
                                    .ComItem(itemDaNotaBuilder3)
                                    .ComObservacoes("entregar nf pessoalmente")
                                    .NaDataAtual(DateTime.Now)
                                    .Constroi();

            Console.WriteLine(notaFiscalBuilder.RazaoSocial);
            Console.WriteLine(notaFiscalBuilder.Cnpj);

            foreach(var item in notaFiscalBuilder.Itens)
            {
                Console.WriteLine(item.Valor);    
            }

            Console.WriteLine(notaFiscalBuilder.Observacoes);
            Console.WriteLine(notaFiscalBuilder.DataDeEmissao);

            // Segunda construção sem invocar NaDataAtual
            TesteDesingPatternsBuilder.NotaFiscal notaFiscalBuilder2 = new TesteDesingPatternsBuilder.NotaFiscalBuilder().ParaEmpresa("Shindi")
                                    .ComCnpj("123.456.789/0001-10")
                                    .ComItem(itemDaNotaBuilder1)
                                    .ComItem(itemDaNotaBuilder2)
                                    .ComItem(itemDaNotaBuilder3)
                                    .ComObservacoes("entregar nf pessoalmente")
                                    .Constroi();

            Console.WriteLine(notaFiscalBuilder2.RazaoSocial);
            Console.WriteLine(notaFiscalBuilder2.Cnpj);

            foreach(var item in notaFiscalBuilder2.Itens)
            {
                Console.WriteLine(item.Valor);    
            }

            Console.WriteLine(notaFiscalBuilder2.Observacoes);
            Console.WriteLine(notaFiscalBuilder2.DataDeEmissao);
        }

        // Controlar transição de Status e suas ações
        // Você tem uma entidade que possui um estado inicial e seus processos,
        // sendo que cada processo vai ser executado de uma forma diferente
        // dependendo do seu status atual
        private static void TesteDesingPatternsStateContaPositivaNegativa()
        {
            var conta = new TesteDesingPatternsState.ContaBancaria(300);
            
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta.ObterEstadoConta());

            conta.Deposito(100);
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta.ObterEstadoConta());

            conta.Saque(500);
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta.ObterEstadoConta());

            conta.Deposito(1000);
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta.ObterEstadoConta());
        }

        // Controlar transição de Status e suas ações
        private static void TesteDesingPatternsState()
        {
            TesteDesingPatternsState.Orcamento orcamento = new TesteDesingPatternsState.Orcamento(500);

            orcamento.AplicaDescontoExtra();
            Console.WriteLine(orcamento.Valor);

            orcamento.Aprovar();
            orcamento.AplicaDescontoExtra();

            Console.WriteLine(orcamento.Valor);

            orcamento.Finaliza();
            orcamento.AplicaDescontoExtra();

            Console.WriteLine(orcamento.Valor);
        }

        // Abstrai uma regra de negócio que se repete em uma classe Abstrata 
        // É um complemento do strategy onde existe um nível a mais que é uma
        // classe abstrata que possui um método "executar" com regras internas
        // que são iguais para um grupo específico de entidades
        // que podem ser sobreescritas quando for criado uma classe
        // herdada desse tipo
        private static void TesteTemplateMethod()
        {
            Console.WriteLine("Template Method");
            TesteDesingPatternsTemplateMethod.Orcamento orcamento = new TesteDesingPatternsTemplateMethod.Orcamento(500);
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 1", 200));
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 2", 250));
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 3", 50));
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 4", 2.50));
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 5", 6.90));
            orcamento.AddItem(new TesteDesingPatternsTemplateMethod.Item("Produto 6", 600));

            TesteDesingPatternsTemplateMethod.CalculaImposto calcularoImposto = new TesteDesingPatternsTemplateMethod.CalculaImposto();

            TesteDesingPatternsTemplateMethod.ImpostoIKCV impostoIKCV = new TesteDesingPatternsTemplateMethod.ImpostoIKCV();
            TesteDesingPatternsTemplateMethod.ImpostoICPP impostoICPP = new TesteDesingPatternsTemplateMethod.ImpostoICPP();

            var valorImpostoIKCV = calcularoImposto.Calcula(orcamento, impostoIKCV);
            var valorImpostoICPP = calcularoImposto.Calcula(orcamento, impostoICPP);

            Console.WriteLine("valorImpostoIKCV:" + valorImpostoIKCV);
            Console.WriteLine("valorImpostoICPP:" + valorImpostoICPP);

            Console.WriteLine("Fim Teste Template Method");
        }

        // Encadear processamento de regras if/else if/ ...
        // Uma alternativa para remover ifs e elses
        // onde se tem classes encadeadas que vão executar algo
        // dependendo de uma condição, caso não atenda a condição
        // chama a próxima classe encadeada. Finaliza quando atende
        // a condição de uma classe ou cai em um comportamento default
        private static void TesteChainOfResponsability()
        {
            Console.WriteLine("Iniciando Teste Chain of Responsability");

            TesteDesingPatternsChainOfResponsability.Orcamento orcamento = new TesteDesingPatternsChainOfResponsability.Orcamento(900);
            
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 1", 200));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 2", 250));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 3", 50));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 4", 2.50));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 5", 6.90));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("Produto 6", 600));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("LAPIS", 1));
            orcamento.AddItem(new TesteDesingPatternsChainOfResponsability.Item("CANETA", 1));

            TesteDesingPatternsChainOfResponsability.CalculadorDesconto calculadorDesconto = new TesteDesingPatternsChainOfResponsability.CalculadorDesconto();

            TesteDesingPatternsChainOfResponsability.Desconto desconto1 = new TesteDesingPatternsChainOfResponsability.DescontoCincoItens();
            TesteDesingPatternsChainOfResponsability.Desconto desconto2 = new TesteDesingPatternsChainOfResponsability.DescontoValorMaiorQuinhentos();
            TesteDesingPatternsChainOfResponsability.Desconto semDesconto = new TesteDesingPatternsChainOfResponsability.SemDesconto();
            TesteDesingPatternsChainOfResponsability.Desconto descontoPorVendaCasada = new TesteDesingPatternsChainOfResponsability.DescontoPorVendaCasada();

            desconto1.Proximo = desconto2;

            desconto2.Proximo = descontoPorVendaCasada;
            descontoPorVendaCasada.Proximo = semDesconto;

            var valor = calculadorDesconto.Calcular(orcamento, desconto1);

            Console.WriteLine("Valor:" + valor);
            Console.WriteLine("Fim Teste Chain of Responsability");
        }

        // Encapsular comportamento similares de forma genérica
        // Implementa um dos princípios do SOLID aberto para extensão
        // e fechado para alteração
        // Você cria uma classe que irá executar um processo e receberá como parâmetro
        // Interfaces ou Classes base para que possa ser passado classes
        // herdadas que vão possuir códigos de execução diferentes
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

        // Junta comportamentos relacionados para entregar um resultado final
        // Caso precise executar uma série de processos que se complementam
        // é criado um encadeamento de classes, cada um com um processo diferente 
        // que no final se complementam para retornar um valor ou comportamento desejado
        private static void TesteDesingPatternsDecorator() {

            Console.WriteLine("Iniciando Teste Decorator");

            TesteDesingPatternsDecorator.ImpostoINSS impostoINSS = new TesteDesingPatternsDecorator.ImpostoINSS(
                new TesteDesingPatternsDecorator.ImpostoICCC(
                    new TesteDesingPatternsDecorator.ImpostoMuitoAlto()));
            TesteDesingPatternsDecorator.Orcamento orcamento = new TesteDesingPatternsDecorator.Orcamento(500);

            double valor = impostoINSS.Calcular(orcamento);

            Console.WriteLine("Valor imposto INSS Decorator:" + valor);

            Console.WriteLine("Fim Teste Decorator");
        }
    }
}
