namespace TesteDesingPatternsStrategy {

    public class ImpostoICCC : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
			if(orcamento.Valor < 1000)
                return orcamento.Valor * 0.05;
            if (orcamento.Valor >= 1000 && orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07;
            else
                return (orcamento.Valor * 0.08) + 30;
        }
    }
}