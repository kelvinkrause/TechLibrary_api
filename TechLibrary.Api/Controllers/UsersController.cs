using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")] //controller serve para servir de rota = Users
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("Create")]
        /*
         * ResponseRegistredUserJson será o retono da API para o usuário, assim que ele realizar o 
         * [Post] com o Nome, Email e Senha
         */
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request) 
        {
            try
            {
                var useCase = new RegisterUserUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (TechLibraryException ex)
            {
                return BadRequest(new ResponseErrorMessageJson
                {
                    Errors = ex.GetErrorMessage()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson
                {
                    Errors = [ "Erro Desconhecido" ]
                });
            }

        }

    }
}
