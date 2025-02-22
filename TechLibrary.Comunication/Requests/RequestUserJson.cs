using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Requests;
public class RequestUserJson
{
    public string Name { get; set; } = string.Empty; 
    // string.Empty; => sempre que criado será criado com string vazia e não null()
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
