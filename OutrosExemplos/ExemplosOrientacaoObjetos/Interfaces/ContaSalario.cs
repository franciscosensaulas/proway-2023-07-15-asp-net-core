namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal class ContaSalario : IContaDeposito, IContaSaque
    {
        public decimal Saldo { get; private set; } = 0;

        public void Depositar(decimal valor)
        {
            Saldo += valor * 1.05m;
        }

        public void Sacar(decimal valor)
        {
            if (Saldo - valor < 0)
            {
                throw new Exception("Conta não possuí saldo suficiente para a operação");
            }

            Saldo = valor;
        }

        public void SacarUtilizandoChequeEspecial(decimal valor)
        {
            throw new Exception(
                "Conta Salário não tem habilitado a opção de saque com Cheque Especial");
        }
    }
}
