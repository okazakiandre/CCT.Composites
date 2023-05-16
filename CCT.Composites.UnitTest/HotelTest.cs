using CCT.Composites.App.Domain;

namespace CCT.Composites.UnitTest
{
    [TestClass]
    [TestCategory("AtualizarPacote refatorado")]
    public class HotelTest
    {
        [TestMethod]
        public void DeveriaManterValoresDoHotelAoAtualizar()
        {
            var hotelNovo = new Hotel { IdHotel = 99 };
            var hotelAntigo = new Hotel
            {
                IdHotel = 99,
                ValorAdicionais = 1.1,
                ValorLiquido = 2.2,
                ValorTotalEstadia = 3.3,
                Quartos = new List<Quarto>()
            };

            hotelNovo.ManterValoresAoAtualizar(hotelAntigo);

            Assert.AreEqual(1.1, hotelNovo.ValorAdicionais);
            Assert.AreEqual(2.2, hotelNovo.ValorLiquido);
            Assert.AreEqual(3.3, hotelNovo.ValorTotalEstadia);
        }

        [TestMethod]
        public void NaoDeveriaManterValoresDoHotelAoAtualizar()
        {
            var hotelNovo = new Hotel();
            var hotelAntigo = new Hotel
            {
                IdHotel = 99,
                ValorAdicionais = 1.1,
                ValorLiquido = 2.2,
                ValorTotalEstadia = 3.3
            };

            hotelNovo.ManterValoresAoAtualizar(hotelAntigo);

            Assert.AreEqual(0, hotelNovo.ValorAdicionais);
            Assert.AreEqual(0, hotelNovo.ValorLiquido);
            Assert.AreEqual(0, hotelNovo.ValorTotalEstadia);
        }

        [TestMethod]
        public void DeveriaObterQuartoPorId()
        {
            var hotel = new Hotel
            {
                Quartos = new List<Quarto>
                {
                    new Quarto { IdQuarto = 1 },
                    new Quarto { IdQuarto = 2 }
                }
            };

            var res = hotel.ObterQuarto(2);

            Assert.AreEqual(2, res.IdQuarto);
        }

        [TestMethod]
        public void DeveriaRetornarErroAoObterQuartoPorIdSeAListaForNulaOuVazia()
        {
            var hotel = new Hotel();
            var exc = Assert.ThrowsException<Exception>(() => hotel.ObterQuarto(2));
            Assert.AreEqual("Quarto não encontrado.", exc.Message);

            hotel.Quartos = new List<Quarto>();
            exc = Assert.ThrowsException<Exception>(() => hotel.ObterQuarto(2));
            Assert.AreEqual("Quarto não encontrado.", exc.Message);
        }

        [TestMethod]
        public void DeveriaRetornarErroAoObterQuartoPorIdSeNaoEncontrarId()
        {
            var hotel = new Hotel
            {
                Quartos = new List<Quarto>
                {
                    new Quarto { IdQuarto = 1 }
                }
            };

            var exc = Assert.ThrowsException<Exception>(() => hotel.ObterQuarto(2));
            Assert.AreEqual("Quarto não encontrado.", exc.Message);
        }
    }
}