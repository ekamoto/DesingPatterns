using System;

namespace TesteDesingPatternsState
{
    public class EstadoReprovado: IEstadoOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não recebe desconto extra");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não pode ser Aprovado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não pode ser Finalizado");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não pode ser Reprovado novamente");
        }
    }
}
