using CCT.Composites.App.Domain;

namespace CCT.Composites.App.UseCases
{
    public class AtualizarPacoteUseCase
    {
        private IPacoteRepository PacRepo { get; }

        public AtualizarPacoteUseCase(IPacoteRepository repo)
        {
            PacRepo = repo;
        }

        public AtualizarPacoteResponse Executar(AtualizarPacoteRequest req)
        {
            var pacoteAtual = PacRepo.Obter(req.PacoteAlterado.Numero);
            var resultado = false;
            string mensagem;

            if (pacoteAtual is null)
            {
                mensagem = $"Pacote de viagem não encontrado.";
            }
            else
            {
                var pacoteAlterado = req.PacoteAlterado;
                if (pacoteAtual.IndicadorPrecoGarantido)
                {
                    pacoteAlterado = ManterValoresAoAtualizar(req.PacoteAlterado, pacoteAtual);
                }

                PacRepo.Atualizar(pacoteAlterado);

                mensagem = "Pacote de viagem alterado com sucesso.";
                resultado = true;
            }

            return new AtualizarPacoteResponse(mensagem, resultado);
        }

        private PacoteViagem ManterValoresAoAtualizar(PacoteViagem pacoteNovo, PacoteViagem pacoteAntigo)
        {
            for (var h = 0; h < pacoteAntigo.Hoteis.Count; h++)
            {
                pacoteNovo.Hoteis[h].ValorTotalEstadia = pacoteAntigo.Hoteis[h].ValorTotalEstadia;
                pacoteNovo.Hoteis[h].ValorLiquido = pacoteAntigo.Hoteis[h].ValorLiquido;
                pacoteNovo.Hoteis[h].ValorAdicionais = pacoteAntigo.Hoteis[h].ValorAdicionais;

                foreach (var quarto in pacoteAntigo.Hoteis[h].Quartos)
                {
                    var quartoNovo = pacoteNovo.Hoteis[h].Quartos.Find(q => q.IdQuarto == quarto.IdQuarto);
                    quartoNovo.ValorDiaria = quarto.ValorDiaria;
                    quartoNovo.ValorDesconto = quarto.ValorDesconto;

                    if (quartoNovo.TaxasExtras != null)
                    {
                        quartoNovo.TaxasExtras.FatorTemporada = quarto.TaxasExtras.FatorTemporada;
                        quartoNovo.TaxasExtras.FatorFimDeSemana = quarto.TaxasExtras.FatorFimDeSemana;
                    }
                }
            }

            return pacoteNovo;
        }
    }
}
