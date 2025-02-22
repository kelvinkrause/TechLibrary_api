using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infraestructure;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password
        };

        var dbContext = new TechLibraryDbContext(); //Instanciando o banco
        dbContext.Users.Add(entity); // Prepara a query para gravar no banco de dados
        dbContext.SaveChanges(); // Grava!

        return new ResponseRegisteredUserJson
        {  
            Name = entity.Name,
            AccessToken = "AINDA EM DESENVOLVIMENTO."
        };
        
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);
        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
