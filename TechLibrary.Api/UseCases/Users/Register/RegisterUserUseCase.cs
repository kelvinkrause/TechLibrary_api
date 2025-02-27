using FluentValidation.Results;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infraestructure.DataAccess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Api.Infraestructure.Security.Tokens.Access;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request)
    {
        var dbContext = new TechLibraryDbContext(); //Instanciando o banco
        
        Validate(request, dbContext);

        var cryptography = new BCryptAlgorithm();

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = cryptography.HashPassword(request.Password)
        };

        dbContext.Users.Add(entity); // Prepara a query para gravar no banco de dados
        dbContext.SaveChanges(); // Grava!

        var tokenGenerator = new JwtTokenGenerator(); // Gera token de acesso do usuário.

        return new ResponseRegisteredUserJson
        {  
            Name = entity.Name,
            AccessToken = tokenGenerator.Generate(entity)
        };
        
    }

    private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request); 
        /*
         * Entra na função do "Validate e executa as validações nos campos recebidos pelo request.
         */

        bool existUsesWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));

        if(existUsesWithEmail)
            result.Errors.Add(new ValidationFailure("Email", "Email já registrado na plataforma."));

        if(result.IsValid == false )
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
