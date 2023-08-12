//using ExemplosOrientacaoObjetos.Interfaces;

//new Principal().Executar();


//using ExemplosOrientacaoObjetos.InterfacesConfirmacaoDados;

//IConfirmacaoCodigoSeguranca confirmacaoCodigoSeguranca;

//Console.WriteLine("Deseja confirmar o código de segurança por qual método?\n1 - SMS\n2 - E-mail");
//int menu = Convert.ToInt32(Console.ReadLine());

//if(menu == 1)
//{
//    confirmacaoCodigoSeguranca = new ConfirmacaoCodigoSegurancaSms();
//}
//else
//{
//    confirmacaoCodigoSeguranca = new ConfirmacaoCodigoSeguarancaEmail();
//}

//string codigo = "A20B30";
//confirmacaoCodigoSeguranca.EnviarCodigo(codigo);


using ExemplosOrientacaoObjetos;


var produtoA = new Produto();
Console.WriteLine(produtoA.Id);


var produtoB = new Produto();
Console.WriteLine(produtoB.Id);


var produtoC = new Produto();
Console.WriteLine(produtoC.Id);