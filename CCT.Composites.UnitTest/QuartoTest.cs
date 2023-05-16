using CCT.Composites.App.Domain;

namespace CCT.Composites.UnitTest
{
    [TestClass]
    [TestCategory("AtualizarPacote refatorado")]
    public class QuartoTest
    {
        [TestMethod]
        public void DeveriaManterValoresDoQuartoAoAtualizar()
        {
            var quartoNovo = new Quarto { IdQuarto = 99 };
            var quartoAntigo = new Quarto
            {
                IdQuarto = 99,
                ValorDesconto = 1.1,
                ValorDiaria = 2.2
            };

            quartoNovo.ManterValoresAoAtualizar(quartoAntigo);

            Assert.AreEqual(1.1, quartoNovo.ValorDesconto);
            Assert.AreEqual(2.2, quartoNovo.ValorDiaria);
        }

        [TestMethod]
        public void NaoDeveriaManterValoresDoQuartoAoAtualizar()
        {
            var quartoNovo = new Quarto();
            var quartoAntigo = new Quarto
            {
                IdQuarto = 99,
                ValorDesconto = 1.1,
                ValorDiaria = 2.2
            };

            quartoNovo.ManterValoresAoAtualizar(quartoAntigo);

            Assert.AreEqual(0, quartoNovo.ValorDesconto);
            Assert.AreEqual(0, quartoNovo.ValorDiaria);
        }

        [TestMethod]
        public void DeveriaManterValoresDasTaxasExtrasDoQuartoAoAtualizar()
        {
            var quartoNovo = new Quarto 
            { 
                IdQuarto = 99,
                TaxasExtras = new TaxasExtras()
            };
            var quartoAntigo = new Quarto
            {
                IdQuarto = 99,
                TaxasExtras = new TaxasExtras
                {
                    FatorFimDeSemana = 1.1,
                    FatorTemporada = 2.2
                }
            };

            quartoNovo.ManterValoresAoAtualizar(quartoAntigo);

            Assert.AreEqual(1.1, quartoNovo.TaxasExtras.FatorFimDeSemana);
            Assert.AreEqual(2.2, quartoNovo.TaxasExtras.FatorTemporada);
        }

        [TestMethod]
        public void NaoDeveriaManterValoresDasTaxasExtrasDoQuartoAoAtualizar()
        {
            var quartoNovo = new Quarto
            {
                IdQuarto = 99
            };
            var quartoAntigo = new Quarto
            {
                IdQuarto = 99,
                TaxasExtras = new TaxasExtras
                {
                    FatorFimDeSemana = 1.1,
                    FatorTemporada = 2.2
                }
            };

            quartoNovo.ManterValoresAoAtualizar(quartoAntigo);

            Assert.IsNull(quartoNovo.TaxasExtras);
        }
    }
}