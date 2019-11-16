using System;

namespace TesteDesingPatternsState
{
    public class EstadoAprovado: IEstadoOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento) 
        {
            orcamento.Valor = orcamento.Valor + (orcamento.Valor * 0.02);
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento aprovado não pode aprovado novamente");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new EstadoFinalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento aprovado não pode reprovado");
        }
    }
}
