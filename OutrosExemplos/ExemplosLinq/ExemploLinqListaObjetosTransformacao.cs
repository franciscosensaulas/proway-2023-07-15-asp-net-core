using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLinq
{
    internal class ExemploLinqListaObjetosTransformacao
    {

        public void Executar()
        {
            var alunos = new List<Aluno>
            {
                new Aluno
                {
                    Nome = "Luiz",
                    Nota1 = 6.00m,
                    Nota2 = 7.50m
                },
                new Aluno
                {
                    Nome = "Lucas",
                    Nota1 = 8m,
                    Nota2 = 7.5m
                }
            };

            var alunosView = alunos
                .Select(aluno => new AlunoView
                {
                    Nome = aluno.Nome,
                    Media = (aluno.Nota1 + aluno.Nota2) / 2
                })
                .ToList();

            foreach (var alunoView in alunosView)
            {
                Console.WriteLine(alunoView.Nome + " - " + alunoView.Media);
            }
        }

        class AlunoView
        {
            public string Nome { get; set; }
            public decimal Media { get; set; }
        }

        class Aluno
        {
            public string Nome { get; set; }
            public decimal Nota1 { get; set; }
            public decimal Nota2 { get; set; }
        }
    }
}
