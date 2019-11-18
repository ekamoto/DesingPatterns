namespace TesteDesingPatternsState
{
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
}