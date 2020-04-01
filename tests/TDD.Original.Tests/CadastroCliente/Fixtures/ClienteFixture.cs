using Bogus;
using Bogus.Extensions.Brazil;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Original.Web.Models;
using TDD.Original.Web.Service;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente.Fixtures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteFixture>
    { }
    public class ClienteFixture
    {
        public List<Cliente> Clientes { get; set; }
        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public Cliente GerarClienteInvalido()
        {
            return new Cliente("", "", DateTime.Now, "");
        }
        public Cliente GerarClienteValido()
        {
            return GerarClientes(1).FirstOrDefault();
        }

        public List<Cliente> GerarClientes(int quantidade)
        {
            var clienteFaker = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(x => new Cliente(
                    x.Person.FullName,
                    x.Person.Cpf(),
                    x.Date.Past(100, DateTime.Now.AddYears(-18)),
                    x.Address.FullAddress()
                    ));

            return clienteFaker.Generate(quantidade);
        }
        
        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            ClienteService = Mocker.CreateInstance<ClienteService>();

            return ClienteService;
        }
    }
}
