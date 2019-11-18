using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDesingPatternsChainOfResponsability
{
    public class DescontoPorVendaCasada : Desconto
    {
        public Desconto Proximo { get; set; }

        private bool Existe(String nomeDoItem, Orcamento orcamento)
        {
            foreach (Item item in orcamento.itens)
            {
                if (item.Descricao.Equals(nomeDoItem))
                    return true;
            }
            return false;
        }

        public double Calcular(Orcamento orcamento)
        {
            if (Existe("LAPIS", orcamento) && Existe("CANETA", orcamento))
            {
                return orcamento.Valor *= 0.05;
            }

            return Proximo.Calcular(orcamento);
        }
    }
}
