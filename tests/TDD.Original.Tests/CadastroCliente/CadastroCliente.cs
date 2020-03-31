using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Linq;
using TDD.Original.Tests.CadastroCliente.Fixtures;
using TDD.Original.Web.Repository;
using TDD.Original.Web.Service;
using Xunit;

namespace TDD.Original.Tests.CadastroCliente
{
    [Collection(nameof(ClienteCollection))]
    public class CadastroCliente : IDisposable
    {
        private readonly ClienteTestFixture _clienteTestFixture;    

        public CadastroCliente(ClienteTestFixture clienteTestFixture)
        {
            _clienteTestFixture = clienteTestFixture;
        }

        [Fact(DisplayName = "Cliente válido")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_EhValida()
        {            
            // Act
            var ehValida = _clienteTestFixture.GerarClienteValido().EhValida();

            // Assert
            Assert.True(ehValida);
        }

        [Fact(DisplayName = "Cliente não é válido")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_NaoValida()
        {
            // Arrange
            var clienteInvalido = _clienteTestFixture.GerarClienteInvalido();
            
                // Act
            var ehValida = clienteInvalido.EhValida();

            // Assert
            Assert.False(ehValida);
            Assert.True(clienteInvalido.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Cadastrado com sucesso")]
        [Trait("Categoria", "Cadastro de Clientes")]        
        public void CadastroCliente_AdicionarCliente_ComSucesso()
        {
            // Arrange
            var pessoa = _clienteTestFixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var _clienteService = mocker.CreateInstance<ClienteService>();
            var _clienteRepository = mocker.GetMock<IClienteRepository>();
            _clienteRepository.Setup(x => x.Adicionar(pessoa)).Returns(true);

            // Act
            var persistido = _clienteService.Adicionar(pessoa);

            // Assert
            Assert.True(persistido);
            persistido.Should().BeTrue();
            _clienteRepository.Verify(x => x.Adicionar(pessoa), Times.Once);
        }

        [Fact(DisplayName = "Cadastrado sem sucesso")]
        [Trait("Categoria", "Cadastro de Clientes")]
        public void CadastroCliente_AdicionarCliente_SemSucesso()
        {
            // Arrange
            var pessoa = _clienteTestFixture.GerarClienteInvalido();
            var _clienteService = new Mock<IClienteService>();

            // Act
            var persistido = _clienteService.Object.Adicionar(pessoa);

            // Assert
            Assert.False(persistido);
            _clienteService.Verify(x => x.Adicionar(pessoa), Times.Once);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
