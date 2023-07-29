using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal interface IContaSaque
    {
        void Sacar(decimal valor);
        void SacarUtilizandoChequeEspecial(decimal valor);
    }
}
