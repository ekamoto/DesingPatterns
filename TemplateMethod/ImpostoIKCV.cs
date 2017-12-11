namespace TesteDesingPatternsTemplateMethod
{
    public class ImpostoIKCV : Imposto
    {
        public ImpostoIKCV()
        {

        }

        public double Calcular(Orcamento orcamento)
        {
            if(orcamento.itens.Count > 5)
            {
                return orcamento.Valor * 5;
            }

            return orcamento.Valor * 7;
        }
    }
}