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

        [Fact(DisplayName = "Instanciar Cliente Válido")]
        [Trait("Categoria", "Cliente")]
        public void InstanciarCliente_ValoresObrigatoriosPreenchidosCorretamente_RetornaTrueEhValida()
        {
            // Act && Assert
            Assert.True(_clienteValido.Validacao.IsValid);
        }

        [Fact(DisplayName = "Instanciar Cliente Inválido")]
        [Trait("Categoria", "Cliente")]
        public void InstanciarCliente_Invalida()
        {
            // Act && Assert
            Assert.False(_clienteValido.Validacao.IsValid);
            Assert.True(_clienteInvalido.Validacao.Errors.Any());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
