using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal class Principal
    {
        public void Executar()
        {
            var contaCorrente = new ContaCorrente();
            contaCorrente.Depositar(100);
            contaCorrente.SacarUtilizandoChequeEspecial(101);

            var contaSalario = new ContaSalario();
            contaSalario.Depositar(100);
            contaSalario.Sacar(10);

            Console.WriteLine($"Conta Corrente: {contaCorrente.Saldo}");
            Console.WriteLine($"Conta Salário: {contaSalario.Saldo}");
        }
    }
}
