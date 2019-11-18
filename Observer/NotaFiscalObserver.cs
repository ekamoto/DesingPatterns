using System;
using System.Collections.Generic;

namespace TesteDesingPatternsObserver
{
    public class NotaFiscalObserver: INotafiscalObserver
    {
        public String RazaoSocial { get; private set; }
        public String Cnpj { get; private set; }
        public double ValorTotal { get; private set; }
        public double Impostos { get; private set; }
        public DateTime Data { get; private set; }
        public String Observacoes { get; private set; }
        public double valorBruto { get; set; }
        public double impostos { get; set; }

        private IList<ItemDaNota> todosItens = new List<ItemDaNota>();

        private IList<AcaoAposGerarNota> acoesAposGerarNota = new List<AcaoAposGerarNota>();

        public NotaFiscalObserver(List<AcaoAposGerarNota> listaAcoes)
        {
            acoesAposGerarNota = listaAcoes;
            Data = DateTime.Now;
        }

        public NotaFiscal Constroi() 
        {
            var nf = new NotaFiscal(RazaoSocial, Cnpj, Data, valorBruto, Impostos, todosItens, Observacoes);
            
            foreach(var acao in acoesAposGerarNota)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        public NotaFiscalObserver ParaEmpresa(String razaoSocial) 
        {
            this.RazaoSocial = razaoSocial;
            return this; // retorno eu mesmo, o próprio Observer, para que o cliente continue utilizando
        }

        public NotaFiscalObserver ComCnpj(String cnpj) 
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalObserver ComItem(ItemDaNota item) 
        {
            todosItens.Add(item);
            valorBruto += item.Valor;
            impostos += item.Valor * 0.05;

            return this;
        }

        public NotaFiscalObserver ComObservacoes(string obs)
        {
            Observacoes = obs;
            return this;
        }
    
        public NotaFiscalObserver NaDataAtual(DateTime data)
        {
            Data = data;
            return this;
        }

        public void AdicionaAcao(AcaoAposGerarNota acao)
        {
            acoesAposGerarNota.Add(acao);
        }
    }
}