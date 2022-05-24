using Application.Validations;
using FluentValidation.Results;

namespace Application.Services
{
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Erros { get; set; }

        public static ResultService RequestError(string mensagem, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucess = false,
                Message = mensagem,
                Erros = validationResult.Errors.Select(x => new ErrorValidation
                {
                    campo = x.PropertyName,
                    mensagem = x.ErrorMessage
                }).ToList()
            };
        }

        public static ResultService<Classe> RequestError<Classe>(string mensagem, ValidationResult validationResult)
        {
            return new ResultService<Classe>
            {
                IsSucess = false,
                Message = mensagem,
                Erros = validationResult.Errors.Select(x => new ErrorValidation
                {
                    campo = x.PropertyName,
                    mensagem = x.ErrorMessage
                }).ToList()
            };
        }

        public static ResultService Fail(string mensagem) => new ResultService { IsSucess = false, Message = mensagem };
        public static ResultService<Classe> Fail<Classe>(string mensagem) => new ResultService<Classe> { IsSucess = false, Message = mensagem };

        public static ResultService Ok(string mensagem) => new ResultService { IsSucess = true, Message = mensagem };
        public static ResultService<Classe> Ok<Classe>(Classe data) => new ResultService<Classe> { IsSucess = true, Result = data };

    }

    public class ResultService<Classe> : ResultService
    {
        public Classe Result { get; set; }
    }
}
