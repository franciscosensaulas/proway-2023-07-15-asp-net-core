namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal abstract class Conta
    {
        public abstract void Depositar(decimal valor);
        public abstract void Sacar(decimal valor);
        public abstract void SacarUtilizandoChequeEspecial(decimal valor);
    }
}
