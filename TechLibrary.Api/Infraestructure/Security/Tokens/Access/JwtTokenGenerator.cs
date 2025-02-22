using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infraestructure.Security.Tokens.Access;

public class JwtTokenGenerator
{

    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor //Descrição de como vai funcionar o token
        {
            Expires = DateTime.UtcNow.AddMinutes(60), 
            // Data de expiração do token de acesso
            Subject = new ClaimsIdentity(claims),
            // Identidade que representa o Token (Pessoa associada ao Token)
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            // Credencial para ele fazer a criptografia
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor); // Cria o token baseado no tokenDescriptor

        return tokenHandler.WriteToken(securityToken); // Descreve o token como um texto
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var signingKey = "M3Lk6L4j07aIxnMgoCJzXEzFZfoU00iZ";

        var symmetricKey = Encoding.UTF8.GetBytes(signingKey);

        return new SymmetricSecurityKey(symmetricKey);
    }
}
