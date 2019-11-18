using System;

namespace TesteDesingPatternsObserver
{
    public class Multiplicador : AcaoAposGerarNota
    {
        public double Fator { get; private set; }

        public Multiplicador(double fator) 
        {
            this.Fator = fator;
        }

        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Multiplicador:" + this.Fator*2);
        }
    }
}