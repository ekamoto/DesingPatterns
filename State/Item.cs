namespace TesteDesingPatternsTemplateMethod
{
    public class Item
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public Item(string descricao, double valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }
    }
}