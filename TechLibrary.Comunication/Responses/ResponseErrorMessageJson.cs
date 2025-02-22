using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Responses;

public class ResponseErrorMessageJson
{
    public List<string> Errors { get; set; } = []; //Inicializando a lista, nunca será null()
}
