using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDesingPatternsState
{
    public class EstadoEmAprovacao: IEstadoOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            orcamento.Valor = orcamento.Valor + (orcamento.Valor * 0.05);
        }

        public void Aprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new EstadoAprovado();
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento em aprovação não pode ser finalizado");
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new EstadoReprovado();
        }
    }
}
