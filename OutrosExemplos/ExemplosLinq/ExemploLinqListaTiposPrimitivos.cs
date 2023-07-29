namespace ExemplosLinq
{
    internal class ExemploLinqListaTiposPrimitivos
    {
        public void Executar()
        {
            var numeros = new List<int> { 2, 9, 3, 11, 15 };

            // Filtrar os números maiores que dez, gerando uma lista com eles.
            //      ANTIGO: 
            //      var numerosMaioresDez = new List<int>();
            //      foreach (var numero in numeros)
            //          if(numero > 10)
            //              numerosMaioresDez.Add(numero);
            //      LINQ:
            var numerosMaioresDez = numeros.Where(numero => numero > 10).ToList();

            // Filtrar os números maiores que três e menores que 12, gerando uma lista
            // Com múltiplos where
            var numerosMaioresTresMenoresDoze = numeros
                .Where(numero => numero > 3)
                .Where(numero => numero < 12)
                .ToList();
            // Único where
            numerosMaioresTresMenoresDoze = numeros
                .Where(numero => numero > 3 && numero < 12)
                .ToList();

            // Ordenar os registros crescente 
            numerosMaioresTresMenoresDoze = numerosMaioresTresMenoresDoze
                .OrderBy(x => x)
                .ToList();

            // Ordenar os registros descrescente
            numerosMaioresTresMenoresDoze = numerosMaioresTresMenoresDoze
                .OrderByDescending(x => x)
                .ToList();

            var palavras = new List<string> { "Abacate", "Mamão", "Pera", "mamão" };

            // Buscar a primeira ocorrencia ou default(null)
            var palavraMamao = palavras.FirstOrDefault(palavra => palavra == "Mamão");

            if (palavraMamao != null)
            {
                Console.WriteLine($"Lista de compras contém {palavraMamao.ToLower()}");
            }
            else
            {
                Console.WriteLine("Devo adicionar mamão na lista de compras");
            }
            // Buscar a última ocorrencia da palavra mamão ignorando caixa alta ou não
            var palavraMamaoUltima = palavras.LastOrDefault(x => x.ToLower() == "mamão");


            var salarios = new List<decimal> { 1800.00m, 2300.92m, 7000.01m };

            var maiorSalario = salarios.Max();
            var menorSalario = salarios.Min();
            var mediaSalario = salarios.Average();


        }
    }
}
