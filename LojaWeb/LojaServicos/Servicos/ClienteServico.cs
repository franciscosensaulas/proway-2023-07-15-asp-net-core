using AutoMapper;
using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ClienteServico(IClienteRepositorio _clienteRepositorio, IMapper mapper)
        {
            _repositorio = _clienteRepositorio;
            _mapper = mapper;
        }

        public void Cadastrar(ClienteCadastrarDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

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

        //private List<ClienteIndexDto> ConstruirClientesDto(List<Cliente> clientes) =>
        //    clientes.Select(x => ClienteIndexDto.ConstruirComEntidade(x)).ToList();
        
        private List<ClienteIndexDto> ConstruirClientesDto(List<Cliente> clientes)
        {
            var dtos = new List<ClienteIndexDto>();

            foreach (var cliente in clientes)
                dtos.Add(ClienteIndexDto.ConstruirComEntidade(cliente));

            return dtos;
        }
    }
}
