using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDesingPatternsState
{
    public interface IEstadoOrcamento
    {
        void AplicaDescontoExtra(Orcamento orcamento);

        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);
    }
}
