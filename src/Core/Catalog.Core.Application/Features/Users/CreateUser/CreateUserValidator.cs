using FluentValidation;

namespace Catalog.Core.Application.Features.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Senha é obrigatória");

            RuleFor(x => x.Password).MinimumLength(8).WithMessage("A senha deverá ter no mínimo 8 caracteres");

            RuleFor(x => x.Password).MaximumLength(8).WithMessage("A senha deverá ter no máximo 20 caracteres");

            RuleFor(x => x.Role).Must(IsValidRole).WithMessage("O perfil do usuário deverá ser 'Administrador', 'Vendedor' ou 'Cliente'");
        }

        private bool IsValidRole(string role)
        {
            return role == "Administrador" || role == "Vendedor" || role == "Cliente";
        }
    }
}
