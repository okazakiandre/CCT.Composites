using CCT.Composites.App.Domain;

namespace CCT.Composites.UnitTest
{
    [TestClass]
    [TestCategory("AtualizarPacote refatorado")]
    public class PacoteViagemTest
    {
        [TestMethod]
        public void DeveriaManterValoresDoPacoteAoAtualizar()
        {
            var pacNovo = new PacoteViagem
            {
                Hoteis = new List<Hotel>
                {
                    new Hotel { Quartos = new List<Quarto>() }
                }
            };
            var pacAntigo = new PacoteViagem
            {
                Hoteis = new List<Hotel>
                {
                    new Hotel { ValorAdicionais = 1.1, Quartos = new List<Quarto>() }
                }
            };

            pacNovo.ManterValoresAoAtualizar(pacAntigo);

            Assert.AreEqual(1.1, pacNovo.Hoteis[0].ValorAdicionais);
        }

    }
}