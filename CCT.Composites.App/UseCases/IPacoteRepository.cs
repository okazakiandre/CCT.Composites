using CCT.Composites.App.Domain;

namespace CCT.Composites.App.UseCases
{
    public interface IPacoteRepository
    {
        long Atualizar(PacoteViagem pacote);
        PacoteViagem Obter(long numero);
    }
}
