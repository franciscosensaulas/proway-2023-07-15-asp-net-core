namespace ExemplosOrientacaoObjetos.InterfacesConfirmacaoDados
{
    internal class ConfirmacaoCodigoSeguarancaEmail : IConfirmacaoCodigoSeguranca
    {
        public void EnviarCodigo(string codigo)
        {
            Console.WriteLine($"Enviando o código '{codigo}' de segurança por e-mail ");
        }
    }
}
