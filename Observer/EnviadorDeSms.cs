namespace TesteDesingPatternsObserver
{
    public class EnviadorDeSms : AcaoAposGerarNota 
    {
        public void Executa(NotaFiscal notaFiscal) 
        {
            System.Console.WriteLine("enviando por sms");
        }
    }
}