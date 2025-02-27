using System.Net;

namespace TechLibrary.Exception;

public class InvalidLoginException : TechLibraryException
{
    
    public override List<string> GetErrorMessage() => ["Email e/ou senha inválidos."];
    
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized; 

}
