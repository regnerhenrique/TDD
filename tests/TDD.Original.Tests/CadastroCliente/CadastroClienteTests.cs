using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using TDD.Original.Tests.CadastroCliente.Fixtures;
using TDD.Original.Web.Models;
using TDD.Original.Web.Repository;
using TDD.Original.Web.Service;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente
{
    [Collection(nameof(ClienteCollection))]
    public class CadastroClienteTests : IDisposable
    {
        private readonly ClienteFixture _clienteFixture;
        private readonly ClienteService _clienteService;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Cliente _clienteValido;
        private readonly Cliente _clienteInvalido;
        private readonly IEnumerable<Cliente> _clientesValidos;

        public CadastroClienteTests(ClienteFixture clienteFixture)
        {
            _clienteFixture = clienteFixture;
            _clienteValido = _clienteFixture.GerarClienteValido();
            _clienteInvalido = _clienteFixture.GerarClienteInvalido();
            _clienteService = _clienteFixture.ObterClienteService();
            _clienteRepository = _clienteFixture.Mocker.GetMock<IClienteRepository>();
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

        [Fact(DisplayName = "Obter maiores de 30 anos")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_ionarCliente_SemSucesso()
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
