namespace TesteDesingPatternsBuilder
{
    public class ItemDaNota
    {
        public ItemDaNota(string descricao, double valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }
        
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}