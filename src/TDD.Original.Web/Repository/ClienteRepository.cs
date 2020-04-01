using System.Collections.Generic;
using TDD.Original.Web.Models;

namespace TDD.Original.Web.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public bool Adicionar(ClienteRepository clienteRepository)
        {
            return false;
        }

        public bool Adicionar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
