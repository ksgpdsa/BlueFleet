using Application.Dto;
using FluentValidation;

namespace Application.Validations
{
    public class VeiculosValidationEditar : AbstractValidator<VeiculosDto>
    {
        public VeiculosValidationEditar()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id não pode ser vazio");

            RuleFor(x => x.Placa).NotEmpty().NotNull().WithMessage("Placa não pode ser vazio");
            RuleFor(x => x.Placa).Length(7).WithMessage("Placa precisa ser igual a 7");

            RuleFor(x => x.Modelo).NotEmpty().NotNull().WithMessage("Modelo não pode ser vazio");
            RuleFor(x => x.Modelo).MinimumLength(2).WithMessage("Modelo não pode ser menor que 2");
            RuleFor(x => x.Modelo).MaximumLength(100).WithMessage("Modelo não pode ser maior que 100");

            RuleFor(x => x.Montadora).NotEmpty().NotNull().WithMessage("Montadora não pode ser vazio");
            RuleFor(x => x.Montadora).MinimumLength(2).WithMessage("Montadora não pode ser menor que 2");
            RuleFor(x => x.Montadora).MaximumLength(100).WithMessage("Montadora não pode ser maior que 100");
        }
    }
}
