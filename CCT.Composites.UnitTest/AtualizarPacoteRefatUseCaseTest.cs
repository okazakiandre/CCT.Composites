using CCT.Composites.App.Domain;
using CCT.Composites.App.UseCases;
using Moq;

namespace CCT.Composites.UnitTest
{
    [TestClass]
    [TestCategory("AtualizarPacote refatorado")]
    public class AtualizarPacoteRefatUseCaseTest
    {
        [TestMethod]
        public void DeveriaRetornarErroSeNaoEncontrarPacoteAoAtualizar()
        {
            var mockRepo = new Mock<IPacoteRepository>();
            var usc = new AtualizarPacoteRefatUseCase(mockRepo.Object);
            var req = new AtualizarPacoteRequest(new PacoteViagem());

            var res = usc.Executar(req);

            Assert.IsFalse(res.Sucesso);
            Assert.AreEqual("Pacote de viagem não encontrado.", res.Mensagem);
        }

        [TestMethod]
        public void DeveriaRetornarSucessoAoAtualizarPacote()
        {
            var mockRepo = new Mock<IPacoteRepository>();
            mockRepo.Setup(m => m.Obter(It.IsAny<long>())).Returns(new PacoteViagem());
            var usc = new AtualizarPacoteRefatUseCase(mockRepo.Object);
            var req = new AtualizarPacoteRequest(new PacoteViagem());

            var res = usc.Executar(req);

            Assert.IsTrue(res.Sucesso);
            Assert.AreEqual("Pacote de viagem alterado com sucesso.", res.Mensagem);
        }
    }
}