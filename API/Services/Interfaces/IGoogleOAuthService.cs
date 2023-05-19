using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Interfaces;

public interface IGoogleOAuthService
{
    public string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChallenge);

    public Task<TokenResult> ExchangeCodeOnToken(string code, string codeVerifier, string redirectUrl);

    public Task<TokenResult> RefreshTokenAsync(string refreshToken);
    
}