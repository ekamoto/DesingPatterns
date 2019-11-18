using System;

namespace TesteDesingPatternsState
{
    public class ContaBancaria
    {
        public IEstadoConta estadoConta{get; set;}

        public double Saldo {get; private set;}

        public interface IEstadoConta
        {
            void Saca(ContaBancaria conta, double valor);
            void Deposita(ContaBancaria conta, double valor);
        }
        public class ContaNegativa : IEstadoConta
        {
            public void Deposita(ContaBancaria conta, double valor)
            {
                conta.Saldo += valor*0.95;
                if(conta.Saldo >= 0)
                    conta.estadoConta = new ContaPositiva();
            }

            public void Saca(ContaBancaria conta, double valor)
            {
                conta.Saldo -= valor;
                if(conta.Saldo < 0)
                    conta.estadoConta = new ContaNegativa();
            }
        }

        public class ContaPositiva : IEstadoConta
        {
            public void Deposita(ContaBancaria conta, double valor)
            {
                conta.Saldo += valor*0.98;
                if(conta.Saldo >= 0)
                    conta.estadoConta = new ContaPositiva();
            }

            public void Saca(ContaBancaria conta, double valor)
            {
                conta.Saldo -= valor;
                if(conta.Saldo < 0)
                    conta.estadoConta = new ContaNegativa();
            }
        }

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