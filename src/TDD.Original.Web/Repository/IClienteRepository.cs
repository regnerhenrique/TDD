using System.Collections.Generic;
using TDD.Original.Web.Models;

namespace TDD.Original.Web.Repository
{
    public interface IClienteRepository
    {
        bool Adicionar(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
    }
}
