using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos
{
    public class Produto
    {
        public static int IndiceId = 1;
        public int Id { get; set; }

        public Produto()
        {
            Id = Produto.IndiceId;
            Produto.IncrementarStatic();
        }

        public static void IncrementarStatic()
        {
            IndiceId++;
        }
    }
}
