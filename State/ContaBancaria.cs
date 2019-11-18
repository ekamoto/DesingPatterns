using System;

namespace TesteDesingPatternsState
{
    public class ContaBancaria
    {
        public IEstadoConta estadoConta{get; set;}

        public double Saldo {get; set;}

        public ContaBancaria(double saldo)
        {
            this.Saldo = saldo;
            estadoConta = new ContaPositiva();
        }

        public void Saque(double valor)
        {
            estadoConta.Saca(this, valor);
        }

        public void Deposito(double valor)
        {
            estadoConta.Deposita(this, valor);
        }

        public string ObterEstadoConta()
        {
            if(estadoConta.GetType() == new ContaNegativa().GetType())
            {
                return "Negativa";
            } else {
                return "Positiva";
            }
        }
    }
}