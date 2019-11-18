namespace TesteDesingPatternsState
{
    public interface IEstadoConta
    {
        void Saca(ContaBancaria conta, double valor);
        void Deposita(ContaBancaria conta, double valor);
    }
}