using APIServices.Domain.DTOs;
using FluentValidation;

namespace APIServices.Infraestructure.Validators
{
    public class UsuariosValidator : AbstractValidator<UsuariosDto>
    {
        public UsuariosValidator()
        {
            RuleFor(usuario => usuario.Contra)
                .NotNull()
                //Condicion de caracteres
                .Length(8, 14);
                //.Length(3, 5);

        }

    }
}
