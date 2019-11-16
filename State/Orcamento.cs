using System;
using System.Collections.Generic;

namespace TesteDesingPatternsState {
    public class Orcamento {

        public IEstadoOrcamento EstadoAtual { get; set; }

        public double Valor { get; set; }

        public IList<Item> itens { get; set; }

        public void AplicaDescontoExtra() 
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }

        public Orcamento(double Valor)
        {
            EstadoAtual = new EstadoEmAprovacao();
            this.Valor = Valor;
            itens = new List<Item>();
        }

        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }

        public void Aprovar()
        {
            EstadoAtual.Aprova(this);
        }

        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }

        public void AddItem(Item item)
        {
            this.itens.Add(item);
        }
    }
}