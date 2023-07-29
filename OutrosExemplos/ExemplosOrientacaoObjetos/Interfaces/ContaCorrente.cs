namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal class ContaCorrente : IContaDeposito, IContaSaque
    {
        public decimal Saldo { get; private set; } = 0;

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (Saldo - valor < 0)
            {
                throw new Exception("Utilizar o menu de Saque com Cheque Especial");
            }

            Saldo -= valor;
        }

        public void SacarUtilizandoChequeEspecial(decimal valor)
        {
            Saldo -= valor;
        }
    }
}
