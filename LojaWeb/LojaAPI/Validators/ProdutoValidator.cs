using FluentValidation;
using LojaAPI.Models.Produto;

namespace LojaAPI.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoCreateModel>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado")
                .NotEmpty()
                .WithMessage("{PropertyName} não deve ser vazio")
                .MinimumLength(3)
                .WithMessage("{PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(40)
                .WithMessage("{PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(x => x.PrecoUnitario)
                .GreaterThan(0)
                .WithMessage("{PropertyName} deve ser maior que 0");

        }
    }
}
