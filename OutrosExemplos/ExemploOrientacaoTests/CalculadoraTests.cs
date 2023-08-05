using ExemplosOrientacaoObjetos;
using Xunit;
using Xunit.Sdk;

namespace ExemploOrientacaoTests
{
    public class CalculadoraTests
    {
        [Fact]
        public void TestSomaNumero8000Mais1()
        {
            // Arrange (preparar o que é necessário para o a execução do ato do teste)
            var hp = new Calculadora();

            // Act (chamar o método Somar passando dois números)
            var resultadoSoma = hp.Somar(8000, 1);

            // Assert (validar que o resultado do Somar é o valor correto
            Assert.Equal(8001, resultadoSoma);
        }

        [Theory]
        [InlineData(-8000, 1, -7999)]
        [InlineData(1, -8000, -7999)]
        [InlineData(-1, -1, -2)]
        public void TestSomarMultiplosCenarios(int numero1, int numero2, int somaEsperada)
        {
            // Arrange
            var hp = new Calculadora();

            // Act
            var resultadoSoma = hp.Somar(numero1, numero2);

            // Assert
            Assert.Equal(somaEsperada, resultadoSoma);
        }

        [Fact]
        public void TestSomarNumeroUmNegativoDeveLancarExcecao()
        {
            // Arrange
            var hp = new Calculadora();

            // Act
            Action act = () => hp.Somar(-1000, 20);

            // Assert
            var exception = Assert.Throws<Exception>(act);

            Assert.Equal("Número 1 não deve conter números negativos", exception.Message);
        }
    }
}
