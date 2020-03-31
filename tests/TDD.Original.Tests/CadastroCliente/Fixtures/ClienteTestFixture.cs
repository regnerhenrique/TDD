using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using TDD.Original.Web.Models;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente.Fixtures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestFixture>
    { }
    public class ClienteTestFixture
    {
        public List<Cliente> Clientes { get; set; }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente("", "", DateTime.Now, "");
        }
        public Cliente GerarClienteValido()
        {
            return new Faker<Cliente>("pt_BR")
                .CustomInstantiator(x => new Cliente(
                    x.Person.FullName,
                    x.Person.Cpf(),
                    x.Date.Past(100, DateTime.Now.AddYears(-18)),
                    x.Address.FullAddress()
                    ));
        }
    }
}
