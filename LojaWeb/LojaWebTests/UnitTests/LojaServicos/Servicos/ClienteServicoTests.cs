using LojaRepositorios.Database;
using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Servicos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace LojaWebTests.UnitTests.LojaServicos.Servicos
{
    public class ClienteServicoTests
    {
        [Fact]
        public void Test_Cadastrar_Cliente_Nao_Cadastrado_Anteriormente_Sucesso()
        {
            // Arrange
            var clienteRepositorioMock = Substitute.For<IClienteRepositorio>();

            var clienteServico = new ClienteServico(clienteRepositorioMock);

            var clienteCadastrarDto = new ClienteCadastrarDto
            {
                Nome = "Julio",
                Cpf = "123.456.789-11",
                DataNascimento = new DateTime(2000, 06, 20),
                Estado = "PA",
                Cidade = "Boa Vista",
                Bairro = "Bairro das Avenidas",
                Cep = "90909-900",
                Complemento = "Casa verde",
                Logradouro = "Rua XY de Outubro",
                Numero = "200"
            };

            clienteRepositorioMock.ObterPorCpf(Arg.Is("123.456.789-10")).ReturnsNull();

            // Act
            clienteServico.Cadastrar(clienteCadastrarDto);

            // Assert
            clienteRepositorioMock.Received(1).ObterPorCpf(Arg.Is("123.456.789-10"));

            clienteRepositorioMock
                .Received(1)
                .Cadastrar(Arg.Is<Cliente>(clienteParametro => RecebeuClienteEsperado(clienteParametro)));
        }

        [Fact]
        public void Test_Cadastrar_Erro_Devido_Cliente_Cadastrado_Anteriormente()
        {
            // Arrange
            var clienteRepositorio = Substitute.For<IClienteRepositorio>();

            var clienteServico = new ClienteServico(clienteRepositorio);

            var clienteCadastrarDto = new ClienteCadastrarDto
            {
                Nome = "Pedro",
                Cpf = "234.567.890-12"
            };

            var clienteExistente = new Cliente();
            clienteRepositorio.ObterPorCpf(Arg.Is("234.567.890-12")).Returns(clienteExistente);

            // Act
            Action acao = () => clienteServico.Cadastrar(clienteCadastrarDto);

            // Assert
            var excecao = Assert.Throws<Exception>(acao);
            Assert.Equal("Cliente já cadastrado com CPF: 234.567.890-12", excecao.Message);

            clienteRepositorio.DidNotReceive().Cadastrar(Arg.Any<Cliente>());
        }

        public bool RecebeuClienteEsperado(Cliente cliente)
        {
            Assert.Equal("Julio", cliente.Nome);
            Assert.Equal("123.456.789-10", cliente.Cpf);
            Assert.Equal(new DateTime(2000, 06, 20), cliente.DataNascimento);
            Assert.Equal("PA", cliente.Endereco.Estado);
            Assert.Equal("Boa Vista", cliente.Endereco.Cidade);
            Assert.Equal("Bairro das Avenidas", cliente.Endereco.Bairro);
            Assert.Equal("90909-900", cliente.Endereco.Cep);
            Assert.Equal("Casa verde", cliente.Endereco.Complemento);
            Assert.Equal("Rua XY de Outubro", cliente.Endereco.Logradouro);
            Assert.Equal("200", cliente.Endereco.Numero);
            Assert.Equal(0, cliente.Id);

            return true;
        }
    }
}
