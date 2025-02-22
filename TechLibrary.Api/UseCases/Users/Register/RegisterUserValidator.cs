using FluentValidation;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register;

//Instalado a dependência FluentValidation para fazer a validação dos campos da requestApi
public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        //Criado regra para quando o nome for vazio, retornar a seguinte mensagem abaixo.
        RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(request => request.Email).EmailAddress().WithMessage("O email não é valido.");
        RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória.");
        When(request => string.IsNullOrEmpty(request.Password) == false, () => //Função Anonima
        {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve conter mais do que 6 caracteres. ");
        });
        
    }

}
