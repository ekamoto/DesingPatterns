using System;

namespace TesteDesingPatternsObserver
{
    public interface INotafiscalObserver
    {
        NotaFiscal Constroi();
        NotaFiscalObserver ParaEmpresa(String razaoSocial);
        NotaFiscalObserver ComCnpj(String cnpj);
        NotaFiscalObserver ComItem(ItemDaNota item);
        NotaFiscalObserver ComObservacoes(string obs);
        NotaFiscalObserver NaDataAtual(DateTime data);
        void AdicionaAcao(AcaoAposGerarNota acao);
    }
}