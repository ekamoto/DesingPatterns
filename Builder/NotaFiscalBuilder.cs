using System;
using System.Collections.Generic;

namespace TesteDesingPatternsBuilder
{
    public class NotaFiscalBuilder: INotafiscalBuilder
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

        public NotaFiscalBuilder()
        {
            Data = DateTime.Now;
        }

        public NotaFiscal Constroi() 
        {
            return new NotaFiscal(RazaoSocial, Cnpj, Data, valorBruto, Impostos, todosItens, Observacoes);
        }

        public NotaFiscalBuilder ParaEmpresa(String razaoSocial) 
        {
            this.RazaoSocial = razaoSocial;
            return this; // retorno eu mesmo, o próprio builder, para que o cliente continue utilizando
        }

        public NotaFiscalBuilder ComCnpj(String cnpj) 
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item) 
        {
            todosItens.Add(item);
            valorBruto += item.Valor;
            impostos += item.Valor * 0.05;

            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string obs)
        {
            Observacoes = obs;
            return this;
        }
    
        public NotaFiscalBuilder NaDataAtual(DateTime data)
        {
            Data = data;
            return this;
        }
    }
}