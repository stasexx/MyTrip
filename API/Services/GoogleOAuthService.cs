using API.Services.Helpers;
using API.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace API.Services;

public class GoogleOAuthService : IGoogleOAuthService
{
    private const string ClientId = "181736966870-p9ttm86o2f4586i07ldte8jjajc7e2m4.apps.googleusercontent.com";
    private const string OAuthServerEndPoint = "https://accounts.google.com/o/oauth2/v2/auth";
    private const string ClientSecret = "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";
    private const string TokenServerEndpoint = "https://oauth2.googleapis.com/token";

    public string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChallenge)
    {
        var queryParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "redirect_uri", redirectUrl },
            { "response_type", "code" },
            { "scope", scope },
            { "code_challenge", codeChallenge },
            { "code_challenge_method", "S256" },
            { "access_type", "offline"}
        };
        var url = QueryHelpers.AddQueryString(OAuthServerEndPoint, queryParams);
        return url;
    }

    public async Task<TokenResult> ExchangeCodeOnToken(string code, string codeVerifier, string redirectUrl)
    {
        var authParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "code", code },
            { "code_verifier", codeVerifier },
            { "grant_type", "authorization_code" },
            { "redirect_uri", redirectUrl }
        };

        var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(TokenServerEndpoint, authParams);
        return tokenResult;
    }
    
    public async Task<TokenResult> RefreshTokenAsync(string refreshToken)
    {
        var refreshParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "grant_type", "refresh_token" },
            { "refresh_token", refreshToken }
        };

        var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(TokenServerEndpoint, refreshParams);

        return tokenResult;
    }
    
    
}