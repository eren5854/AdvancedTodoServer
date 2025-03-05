using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using AdvancedTodoServer.WebAPI.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdvancedTodoServer.WebAPI.Services;

public class JwtProvider(
    IOptions<JwtOption> jwtOption) : IJwtProvider
{
    public Task<LoginResponseDto> CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            //new Claim("UserName", user.UserName ?? ""),
            //new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        DateTime expires = DateTime.Now.AddMonths(6);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOption.Value.Issuer,
            audience: jwtOption.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);

        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshTokenExpires = expires;

        //user.RefreshToken = refreshToken;
        //user.RefreshTokenExpires = refreshToneExpires;

        //await userManager.UpdateAsync(user);

        return Task.FromResult(new LoginResponseDto(token, refreshToken, refreshTokenExpires));
    }
}
