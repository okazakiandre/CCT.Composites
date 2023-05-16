namespace CCT.Composites.App.Domain
{
    public class PacoteViagem
    {
        public long Numero { get; set; }
        public bool IndicadorPrecoGarantido { get; set; }
        public List<Hotel> Hoteis { get; set; }

        public void ManterValoresAoAtualizar(PacoteViagem pacoteAntigo)
        {
            for (var h = 0; h < pacoteAntigo.Hoteis.Count; h++)
            {
                var hotelNovo = ObterHotel(pacoteAntigo.Hoteis[h].IdHotel);
                hotelNovo.ManterValoresAoAtualizar(pacoteAntigo.Hoteis[h]);
            }
        }

        public Hotel ObterHotel(int id)
        {
            var hotel = Hoteis?.Find(h => h.IdHotel == id);
            if (hotel is null)
            {
                throw new Exception("Hotel não encontrado.");
            }
            return hotel;
        }
    }
}
