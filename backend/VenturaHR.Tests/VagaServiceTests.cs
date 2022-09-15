using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Repositories;
using VenturaHR.Domain.Services;

namespace VenturaHR.Tests
{
    public class VagaServiceTests
    {
        [Fact]
        public void VagaService_ShouldCreateVaga_Successfully()
        {
            // Arrange
            Fixture fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            var vagaRepository = new Mock<IVagaRepository>();

            var expected = fixture.Create<Vaga>();

            vagaRepository.Setup(x => x.Add(It.IsAny<Vaga>())).Verifiable();

            fixture.Inject(vagaRepository.Object);


            // Act           
            var sut = fixture.Create<VagaService>();

            sut.CreateVaga(expected);

            // Assert
            vagaRepository.Verify(x => x.Add(It.IsAny<Vaga>()), Times.Once);

        }

        [Fact]
        public void VagaService_ShouldGetVaga_Successfully()
        {
            // Arrange
            Fixture fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            var vagaRepository = new Mock<IVagaRepository>();

            var expected = fixture.Create<Vaga>();

            vagaRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Vaga, bool>>>())).Returns(expected);

            fixture.Inject(vagaRepository.Object);

            var sut = fixture.Create<VagaService>();

            // Act
            var actual = sut.GetVaga(expected.Id);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void VagaService_ShouldUpdateVaga_Successfully()
        {
            // Arrange
            Fixture fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            var vagaRepository = new Mock<IVagaRepository>();

            var expected = fixture.Create<Vaga>();

            vagaRepository.Setup(x => x.Update(It.IsAny<Vaga>())).Verifiable();

            fixture.Inject(vagaRepository.Object);


            // Act           
            var sut = fixture.Create<VagaService>();

            sut.UpdateVaga(expected.Id, expected);

            // Assert
            vagaRepository.Verify(x => x.Update(It.IsAny<Vaga>()), Times.Once);
        }

        [Fact]
        public void VagaService_ShouldDeleteVaga_Successfully()
        {
            // Arrange
            Fixture fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            var vagaRepository = new Mock<IVagaRepository>();

            var expected = fixture.Create<Vaga>();

            vagaRepository.Setup(x => x.DeleteById(It.IsAny<int>())).Verifiable();

            fixture.Inject(vagaRepository.Object);


            // Act           
            var sut = fixture.Create<VagaService>();

            sut.DeleteVaga(expected.Id);

            // Assert
            vagaRepository.Verify(x => x.DeleteById(It.IsAny<int>()), Times.Once);
        }
    }
}