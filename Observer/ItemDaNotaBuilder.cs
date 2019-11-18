namespace TesteDesingPatternsObserver
{
    public class ItemDaNotaObserver
    {        
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public ItemDaNota Constroi()
        {
            return new ItemDaNota(Descricao, Valor);
        }
        public ItemDaNotaObserver ComDescricao(string desricao)
        {
            Descricao = desricao;
            return this;
        }
        public ItemDaNotaObserver ComValor(double valor)
        {
            Valor = valor;
            return this;
        }
    }
}