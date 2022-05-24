using Application.Interfaces;
using Application.Validations;
using NToastNotify;

namespace Application.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly IToastNotification _toastNotification;

        public NotificacaoService(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        public bool Notificacao(ResultService<bool> resposta)
        {
            if (resposta.IsSucess)
                _toastNotification.AddSuccessToastMessage(resposta.Message);
            else
            {
                if (resposta.Erros != null && resposta.Erros.Count > 0)
                {
                    foreach (ErrorValidation? erro in resposta.Erros)
                    {
                        _toastNotification.AddErrorToastMessage(erro.mensagem);
                    }
                }
                else
                {
                    _toastNotification.AddErrorToastMessage(resposta.Message);
                }

                return false;
            }

            return true;
        }
    }
}
