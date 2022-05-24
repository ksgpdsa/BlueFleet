using Application.Services;

namespace Application.Interfaces
{
    public interface INotificacaoService
    {
        public bool Notificacao(ResultService<bool> resposta);
    }
}
