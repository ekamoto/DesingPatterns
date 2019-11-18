namespace TesteDesingPatternsBuilder
{
    public class ItemDaNotaBuilder
    {        
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public ItemDaNota Constroi()
        {
            return new ItemDaNota(Descricao, Valor);
        }
        public ItemDaNotaBuilder ComDescricao(string desricao)
        {
            Descricao = desricao;
            return this;
        }
        public ItemDaNotaBuilder ComValor(double valor)
        {
            Valor = valor;
            return this;
        }
    }
}