using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Exception;

public class ErrorOnValidationException : TechLibraryException
{
    private readonly List<string> _errors; //_ => serve para indicar que é uma variável privada
    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrorMessage() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest; //Erro 400 (A requisição contém problemas
}
