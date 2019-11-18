using System;

namespace TesteDesingPatternsObserver
{
    public class EnviadorDeEmail : AcaoAposGerarNota 
    {        
        public void Executa(NotaFiscal notaFiscal) 
        {
            Console.WriteLine("enviando por e-mail");
        }
    }
}