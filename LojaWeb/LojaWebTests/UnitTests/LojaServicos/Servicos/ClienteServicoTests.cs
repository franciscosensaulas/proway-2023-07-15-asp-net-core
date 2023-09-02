// using FluentAssertions;
// using LojaRepositorios.Database;
// using LojaRepositorios.Entidades;
// using LojaRepositorios.Repositorios;
// using LojaServicos.Dtos.Clientes;
// using LojaServicos.Servicos;
// using LojaWebTests.Builders.Entidades;
// using NSubstitute;
// using NSubstitute.ReturnsExtensions;
// using Xunit;
//
// namespace LojaWebTests.UnitTests.LojaServicos.Servicos
// {
//     public class ClienteServicoTests
//     {
//         private readonly ClienteServico _clienteServico;
//         private readonly IClienteRepositorio _clienteRepositorio;
//
//         public ClienteServicoTests()
//         {
//             _clienteRepositorio = Substitute.For<IClienteRepositorio>();
//             _clienteServico = new ClienteServico(_clienteRepositorio);
//         }
//
//         [Fact]
//         public void Test_Cadastrar_Cliente_Nao_Cadastrado_Anteriormente_Sucesso()
//         {
//             // Arrange
//             var clienteCadastrarDto = new ClienteCadastrarDto
//             {
//                 Nome = "Julio",
//                 Cpf = "123.456.789-10",
//                 DataNascimento = new DateTime(2000, 06, 20),
//                 Estado = "PA",
//                 Cidade = "Boa Vista",
//                 Bairro = "Bairro das Avenidas",
//                 Cep = "90909-900",
//                 Complemento = "Casa verde",
//                 Logradouro = "Rua XY de Outubro",
//                 Numero = "200"
//             };
//
//             _clienteRepositorio.ObterPorCpf(Arg.Is("123.456.789-10")).ReturnsNull();
//
//             // Act
//             _clienteServico.Cadastrar(clienteCadastrarDto);
//
//             // Assert
//             _clienteRepositorio
//                 .Received(1)
//                 .Cadastrar(Arg.Is<Cliente>(clienteParametro => RecebeuClienteEsperado(clienteParametro)));
//         }
//
//         [Fact]
//         public void Test_Cadastrar_Erro_Devido_Cliente_Cadastrado_Anteriormente()
//         {
//             // Arrange
//             var clienteCadastrarDto = new ClienteCadastrarDto
//             {
//                 Nome = "Pedro",
//                 Cpf = "234.567.890-12"
//             };
//
//             var clienteExistente = new Cliente();
//             _clienteRepositorio.ObterPorCpf(Arg.Is("234.567.890-12")).Returns(clienteExistente);
//
//             // Act
//             Action acao = () => _clienteServico.Cadastrar(clienteCadastrarDto);
//
//             // Assert
//             // FluentAssertions validação que lançou exceção
//             var exceptionLancada = acao.Should().Throw<Exception>();
//             exceptionLancada.WithMessage("Cliente já cadastrado com CPF: 234.567.890-12");
//
//             // XUNIT validação
//             //var excecao = Assert.Throws<Exception>(acao);
//             //Assert.Equal("Cliente já cadastrado com CPF: 234.567.890-12", excecao.Message);
//
//
//             _clienteRepositorio.DidNotReceive().Cadastrar(Arg.Any<Cliente>());
//         }
//
//         [Fact]
//         public void Test_ObterTodos_Sucesso()
//         {
//             // Arrange
//             var clientesEsperados = new List<Cliente>
//             {
//                 new ClienteBuilder()
//                     .ComNome("Pedro")
//                     .ComId(8001)
//                     .ComCpf("123.456.789-10")
//                     .ComEstado("SC")
//                     .ComCidade("Timbó")
//                     .Construir(),
//                 new ClienteBuilder()
//                     .Construir()
//             };
//
//             _clienteRepositorio.ObterTodos(Arg.Is("")).Returns(clientesEsperados);
//
//             // Act
//             var clientes = _clienteServico.ObterTodos("");
//
//             // Assert
//             // XUnit
//             //Assert.Equal(2, clientes.Count);
//             // Fluent Assertion
//             clientes.Should().HaveCount(2);
//
//             clientes[0].Nome.Should().Be("Pedro");
//             clientes[0].Cpf.Should().Be("123.456.789-10");
//             clientes[0].Id.Should().Be(8001);
//             clientes[0].Endereco.Should().Be("SC - Timbó");
//
//             clientes[1].Nome.Should().Be("Allan de Souze");
//             clientes[1].Cpf.Should().Be("123.456.123-00");
//             clientes[1].Id.Should().Be(9999);
//             clientes[1].Endereco.Should().Be("SC - Gaspar");
//         }
//
//         public bool RecebeuClienteEsperado(Cliente cliente)
//         {
//             cliente.Nome.Should().Be("Julio");
//             cliente.Cpf.Should().Be("123.456.789-10");
//             cliente.Endereco.Estado.Should().Be("PA");
//             cliente.DataNascimento.Should().Be(new DateTime(2000, 06, 20));
//             cliente.Endereco.Cidade.Should().Be("Boa Vista");
//             cliente.Endereco.Bairro.Should().Be("Bairro das Avenidas");
//             cliente.Endereco.Cep.Should().Be("90909-900");
//             cliente.Endereco.Complemento.Should().Be("Casa verde");
//             cliente.Endereco.Logradouro.Should().Be("Rua XY de Outubro");
//             cliente.Endereco.Numero.Should().Be("200");
//             cliente.Id.Should().Be(0);
//
//
//             return true;
//         }
//     }
// }
