using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio _clienteRepositorio)
        {
            _repositorio = _clienteRepositorio;
        }

        public void Cadastrar(ClienteCadastrarDto dto)
        {
            var cliente = ConstruirCliente(dto);

            var clienteExistenteComCpf = _repositorio.ObterPorCpf(dto.Cpf);

            if (clienteExistenteComCpf != null)
                throw new Exception($"Cliente já cadastrado com CPF: {dto.Cpf}");

            _repositorio.Cadastrar(cliente);
        }

        public List<ClienteIndexDto> ObterTodos(string? pesquisa)
        {
            var clientes = _repositorio.ObterTodos(pesquisa);

            var clientesDto = ConstruirClientesDto(clientes);

            return clientesDto;
        }

        private List<ClienteIndexDto> ConstruirClientesDto(List<Cliente> clientes)
        {
            var dtos = new List<ClienteIndexDto>();

            foreach (var cliente in clientes)
            {
                var dto = new ClienteIndexDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Endereco = $"{cliente.Endereco.Estado} - {cliente.Endereco.Cidade}",
                    Cpf = cliente.Cpf
                };
                dtos.Add(dto);
            }

            return dtos;

        }

        private Cliente ConstruirCliente(ClienteCadastrarDto dto)
        {
            return new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                Endereco = new Endereco
                {
                    Estado = dto.Estado,
                    Cidade = dto.Cidade,
                    Bairro = dto.Bairro,
                    Cep = dto.Cep,
                    Logradouro = dto.Logradouro,
                    Numero = dto.Numero,
                    Complemento = dto.Complemento
                }
            };
        }
    }
}
