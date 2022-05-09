using API.Entities;
using FluentValidation;

namespace API.Services
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Tax_id).NotNull().WithMessage("CPF é obrigatório!")
            .MinimumLength(11).MaximumLength(11).WithMessage("O CPF deve conter 11 digitos!");

            RuleFor(client => client.Name).NotNull().WithMessage("Nome é obrigatório!")
            .MinimumLength(3).WithMessage("O campo nome deve ter no minimo 3 caracteres.")
            .MaximumLength(60).WithMessage("O campo nome não deve ter mais que 60 caracteres.");

            RuleFor(client => client.Password).NotNull().WithMessage("Senha é obrigatória!")
            .MinimumLength(8).WithMessage("O campo senha deve ter no minimo 8 caracteres.")
            .MaximumLength(40).WithMessage("O campo senha não deve ter mais que 60 caracteres.");
        }
    }
}
