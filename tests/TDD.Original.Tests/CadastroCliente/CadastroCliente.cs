using FluentAssertions;
using Moq;
using System;
using System.Linq;
using TDD.Original.Tests.CadastroCliente.Fixtures;
using TDD.Original.Web.Models;
using TDD.Original.Web.Repository;
using TDD.Original.Web.Service;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente
{
    [Collection(nameof(ClienteCollection))]
    public class CadastroCliente : IDisposable
    {
        private readonly CadastroClienteFixture _cadastroClienteFixture;
        private readonly ClienteService _clienteService;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Cliente _clienteValido;
        private readonly Cliente _clienteInvalido;

        public CadastroCliente(CadastroClienteFixture clienteTestFixture)
        {
            _cadastroClienteFixture = clienteTestFixture;
            _clienteValido = _cadastroClienteFixture.GerarClienteValido();
            _clienteInvalido = _cadastroClienteFixture.GerarClienteInvalido();
            _clienteService = _cadastroClienteFixture.ObterClienteService();
            _clienteRepository = _cadastroClienteFixture.Mocker.GetMock<IClienteRepository>();
        }

        [Fact(DisplayName = "Cliente válido")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_EhValida()
        {
            // Act && Assert
            Assert.True(_clienteValido.EhValida());
        }

        [Fact(DisplayName = "Cliente não é válido")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_NaoValida()
        {
            // Act && Assert
            Assert.False(_clienteInvalido.EhValida());
            Assert.True(_clienteInvalido.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Cadastrado com sucesso")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_ComSucesso()
        {
            // Arrange
            _clienteRepository.Setup(x => x.Adicionar(_clienteValido)).Returns(true);
            
            // Act && Assert
            _clienteService.Adicionar(_clienteValido).Should().BeTrue();
            _clienteRepository.Verify(x => x.Adicionar(_clienteValido), Times.Once);
        }

        [Fact(DisplayName = "Cadastrado sem sucesso")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_SemSucesso()
        {
            // Act && Assert
            Assert.False(_clienteService.Adicionar(_clienteInvalido));
            _clienteRepository.Verify(x => x.Adicionar(_clienteInvalido), Times.Never);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
