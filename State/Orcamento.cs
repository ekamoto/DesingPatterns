using System;
using System.Collections.Generic;

namespace TesteDesingPatternsState {
    public class Orcamento {

        public int EM_APROVACAO = 1;
        public int APROVADO = 2;
        public int REPROVADO = 3;
        public int FINALIZADO = 4;

        public Orcamento()
        {
            EstadoAtual = EM_APROVACAO;
        }

        public int EstadoAtual { get; set; }

        public double Valor { get; set; }

        public IList<Item> itens { get; set; }

        public void AplicaDescontoExtra() 
        {
            if (EstadoAtual == EM_APROVACAO) Valor = Valor - (Valor * 0.05);
            else if (EstadoAtual == APROVADO) Valor = Valor - (Valor * 0.02);
            else throw new Exception("Lançamento Reprovados/Finalizados não recebem desconto extra");

        }

        public Orcamento(double Valor)
        {
            EstadoAtual = EM_APROVACAO;
            this.Valor = Valor;
            itens = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this.itens.Add(item);
        }
    }
}