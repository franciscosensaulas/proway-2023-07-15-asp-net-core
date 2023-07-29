using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLinq
{
    internal class ExemploLinqListaObjetos
    {

        public void Executar()
        {
            var animes = new List<Anime>();
            var assasinationClassroom = new Anime()
            {
                Id = 1,
                Nome = "Assassination Classroom",
                Categoria = "Comédia",
                QuantidadeTemporadas = 2
            };
            var bleach = new Anime
            {
                Id = 2,
                Nome = "Bleach",
                Categoria = "Shounen",
                QuantidadeTemporadas = 14
            };
            var kurokosBasketball = new Anime()
            {
                Id = 3,
                Nome = "Kuroko's Basketball",
                Categoria = "Esportes",
                QuantidadeTemporadas = 4
            };
            var naruto = new Anime
            {
                Id = 4,
                Nome = "Naruto",
                Categoria = "Shounen",
                QuantidadeTemporadas = 9
            };
            var blackClover = new Anime()
            {
                Id = 5,
                Nome = "Black Cover",
                Categoria = "Shounen",
                QuantidadeTemporadas = 1
            };
            animes.Add(assasinationClassroom);
            animes.Add(bleach);
            animes.Add(kurokosBasketball);
            animes.Add(naruto);
            animes.Add(blackClover);
            // SELECT id, nome, categoria, quantidade_temporadas
            //  FROM animes 
            //  ORDER BY categoria, nome
            var animesOrdenados = animes
                .OrderBy(x => x.Categoria)
                    .ThenBy(x => x.Nome)
                .ToList();
            ApresentarAnimes(animesOrdenados);

            var animesShounenQuantidade = animes
                .Where(x => x.Categoria == "Shounen")
                .Count();

            Console.WriteLine(
                $"___________ ANIMES SHOUNEN ({animesShounenQuantidade}) ___________");
            var animesShounen = animes
                .Where(x => x.Categoria == "Shounen")
                .OrderBy(x => x.Nome)
                .ToList();

            ApresentarAnimes(animesShounen);
        }

        public void ApresentarAnimes(List<Anime> animes)
        {
            foreach (var anime in animes)
            {
                Console.WriteLine($"Nome: {anime.Nome}");
                Console.WriteLine($"Id: {anime.Id}");
                Console.WriteLine($"Categoria: {anime.Categoria}");
                Console.WriteLine($"Quantidade Temporadas: {anime.QuantidadeTemporadas}");
                Console.WriteLine("\n");
            }
        }


        public class Anime
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int QuantidadeTemporadas { get; set; }
            public string Categoria { get; set; }
        }
    }
}
