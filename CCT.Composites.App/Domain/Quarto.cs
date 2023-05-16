namespace CCT.Composites.App.Domain
{
    public class Quarto
    {
        public int IdQuarto { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorDesconto { get; set; }
        public TaxasExtras TaxasExtras { get; set; }

        public void ManterValoresAoAtualizar(Quarto quartoAntigo)
        {
            if (IdQuarto == quartoAntigo.IdQuarto)
            {
                ValorDiaria = quartoAntigo.ValorDiaria;
                ValorDesconto = quartoAntigo.ValorDesconto;

                if (TaxasExtras != null)
                {
                    TaxasExtras.FatorTemporada = quartoAntigo.TaxasExtras.FatorTemporada;
                    TaxasExtras.FatorFimDeSemana = quartoAntigo.TaxasExtras.FatorFimDeSemana;
                }
            }
        }
    }
}
