using System;
using System.Linq;
using TDD.Original.Tests.CadastroCliente.Fixtures;
using TDD.Original.Web.Models;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTests : IDisposable
    {
        private readonly Cliente _clienteValido;
        private readonly Cliente _clienteInvalido;
        private readonly ClienteFixture _clienteFixture;

        public ClienteTests(ClienteFixture clienteFixture)
        {
            _clienteFixture = clienteFixture;
            _clienteValido = _clienteFixture.GerarClienteValido();
            _clienteInvalido = _clienteFixture.GerarClienteInvalido();
        }

        [Fact(DisplayName = "Cliente válido")]
        [Trait("Categoria", "Cliente")]
        public void CadastroCliente_AdicionarCliente_EhValida()
        {
            // Act && Assert
            Assert.True(_clienteValido.EhValida());
        }

        [Fact(DisplayName = "Cliente não é válido")]
        [Trait("Categoria", "Cliente")]
        public void CadastroCliente_AdicionarCliente_NaoValida()
        {
            // Act && Assert
            Assert.False(_clienteInvalido.EhValida());
            Assert.True(_clienteInvalido.ValidationResult.Errors.Any());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
