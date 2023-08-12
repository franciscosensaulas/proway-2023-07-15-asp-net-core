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
                Cpf = "123.456.789-10",
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

        [Fact]
        public void Test_ObterTodos_Sucesso()
        {
            // Arrange
            var clienteRepositorio = Substitute.For<IClienteRepositorio>();

            var clienteServico = new ClienteServico(clienteRepositorio);

            var clientesEsperados = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "Pedro",
                    Id = 8001,
                    Cpf = "123.456.789-10",
                    Endereco = new Endereco
                    {
                        Estado = "SC",
                        Cidade = "Timbó"
                    }
                },
                new Cliente
                {
                    Nome = "Júlia",
                    Id = 8002,
                    Cpf = "234.567.890-12",
                    Endereco = new Endereco
                    {
                        Estado = "SC",
                        Cidade = "Blumenau"
                    }
                }
            };

            clienteRepositorio.ObterTodos(Arg.Is("")).Returns(clientesEsperados);

            // Act
            var clientes = clienteServico.ObterTodos("");

            // Assert
            Assert.Equal(2, clientes.Count);

            Assert.Equal("Pedro", clientes[0].Nome);
            Assert.Equal("123.456.789-10", clientes[0].Cpf);
            Assert.Equal(8001, clientes[0].Id);
            Assert.Equal("SC - Timbó", clientes[0].Endereco);

            Assert.Equal("Júlia", clientes[1].Nome);
            Assert.Equal("234.567.890-12", clientes[1].Cpf);
            Assert.Equal(8002, clientes[1].Id);
            Assert.Equal("SC - Blumenau", clientes[1].Endereco);
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
