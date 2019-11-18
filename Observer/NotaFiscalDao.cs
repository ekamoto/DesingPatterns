using System;

namespace TesteDesingPatternsObserver
{
    public class NotaFiscalDao : AcaoAposGerarNota 
    {
        public void Executa(NotaFiscal notaFiscal) 
        {
            Console.WriteLine("salvando no banco");
        }
    }
}