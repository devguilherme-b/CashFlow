using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security.Token;
public class JwtTokenGenerator : IAccessTokenGenerate
{
    private readonly uint _expirationTimeMinutes;
    private readonly string _signinKey;
    public JwtTokenGenerator(uint expirationTimeMinutes, string signinKey)
    {
        _expirationTimeMinutes = expirationTimeMinutes;
        _signinKey = signinKey;
    }
    public string Generate(User user)
    {
        var claims = new List<Claim>
        {
           new Claim(ClaimTypes.Name, user.Name),
           new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
        };

        // Descreve o Token a ser gerado
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
      
        return tokenHandler.WriteToken(securityToken);
    }

    // Converte _signinKey para o formato key
    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signinKey);
        return new SymmetricSecurityKey(key);
    }
}
