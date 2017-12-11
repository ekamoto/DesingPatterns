namespace TesteDesingPatternsTemplateMethod
{
    class CalculaImposto {

        public double Calcula(Orcamento orcamento, Imposto imposto) {

            return imposto.Calcular(orcamento);
        }
    }
}