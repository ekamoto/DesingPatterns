using System;

namespace TesteDesingPatternsState
{
    public class EstadoFinalizado: IEstadoOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento) 
        {
            throw new Exception("Orçamento Finalizado não recebe desconto extra");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ser Aprovado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ser Finalizado novamente");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ser Reprovado");
        }
    }
}
