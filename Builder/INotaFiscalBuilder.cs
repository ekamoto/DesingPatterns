using System;

namespace TesteDesingPatternsBuilder
{
    public interface INotafiscalBuilder
    {
        NotaFiscal Constroi();
        NotaFiscalBuilder ParaEmpresa(String razaoSocial);
        NotaFiscalBuilder ComCnpj(String cnpj);
        NotaFiscalBuilder ComItem(ItemDaNota item);
        NotaFiscalBuilder ComObservacoes(string obs);
        NotaFiscalBuilder NaDataAtual(DateTime data);
        
    }
}