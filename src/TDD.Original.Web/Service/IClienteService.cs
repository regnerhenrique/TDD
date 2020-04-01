using System.Collections.Generic;
using TDD.Original.Web.Models;

namespace TDD.Original.Web.Service
{
    public interface IClienteService
    {
        bool Adicionar(Cliente cliente);
        IEnumerable<Cliente> ObterMaioresTrintaAnos();
    }
}
