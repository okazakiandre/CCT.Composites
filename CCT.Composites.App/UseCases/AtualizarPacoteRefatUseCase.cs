using CCT.Composites.App.Domain;

namespace CCT.Composites.App.UseCases
{
    public class AtualizarPacoteRefatUseCase
    {
        private IPacoteRepository PacRepo { get; }

        public AtualizarPacoteRefatUseCase(IPacoteRepository repo)
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
                    pacoteAlterado.ManterValoresAoAtualizar(pacoteAtual);
                }

                PacRepo.Atualizar(pacoteAlterado);

                mensagem = "Pacote de viagem alterado com sucesso.";
                resultado = true;
            }

            return new AtualizarPacoteResponse(mensagem, resultado);
        }
    }
}
