using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Login.DoLogin;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult DoLogin(RequestLoginJson request)
    {
        try
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);

            return Ok(response);
        }
        catch (TechLibraryException ex)
        {
            return Unauthorized(new ResponseErrorMessageJson
            {
                Errors = ex.GetErrorMessage()
            });
        }

        //PAREI AQUI 01:25:00
        
        
    }

}
