using TDD.Original.Web.Models;
using TDD.Original.Web.Repository;

namespace TDD.Original.Web.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool Adicionar(Cliente cliente)
        {
            if (cliente.EhValida())
            {
                return _clienteRepository.Adicionar(cliente);
            }

            return false;
        }
    }
}
