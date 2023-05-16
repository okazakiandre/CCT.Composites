namespace CCT.Composites.App.Domain
{
    public class Hotel
    {
        public int IdHotel { get; set; }
        public double ValorTotalEstadia { get; set; }
        public double ValorLiquido { get; set; }
        public double ValorAdicionais { get; set; }
        public List<Quarto> Quartos { get; set; }

        public void ManterValoresAoAtualizar(Hotel hotelAntigo)
        {
            if (IdHotel == hotelAntigo.IdHotel)
            {
                ValorTotalEstadia = hotelAntigo.ValorTotalEstadia;
                ValorLiquido = hotelAntigo.ValorLiquido;
                ValorAdicionais = hotelAntigo.ValorAdicionais;

                foreach (var quartoAntigo in hotelAntigo.Quartos)
                {
                    var quarto = ObterQuarto(quartoAntigo.IdQuarto);
                    quarto.ManterValoresAoAtualizar(quartoAntigo);
                }
            }
        }

        public Quarto ObterQuarto(int id)
        {
            var quarto = Quartos?.Find(q => q.IdQuarto == id);
            if (quarto is null)
            {
                throw new Exception("Quarto não encontrado.");
            }
            return quarto;
        }
    }
}