using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Models;
using API.Services.Interfaces;
using API.Services;
using API.Services.Helpers;
using IdentityModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace API.Controllers;

public class GoogleOAuthController : BaseApiController
{
    private readonly IGoogleOAuthService _googleOAuth;
    
    
    public GoogleOAuthController(IGoogleOAuthService googleOAuth)
    {
        _googleOAuth = googleOAuth;
    }
    
    [HttpPost("api/oauth")]
    public IActionResult RedirectOnOAuthServer()
    {
        var scope = "https://www.googleapis.com/auth/userinfo.email";
        var redirectUrl = "http://localhost:5000/GoogleOAuth/api/oauth/code";

        var codeVerifier = Guid.NewGuid().ToString();
        HttpContext.Session.SetString("codeVerifier", codeVerifier);
        var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);
        var url = _googleOAuth.GenerateOAuthRequestUrl(scope, redirectUrl, codeChallenge);
        return Redirect(url);
    }
    
    [HttpGet("api/oauth/code")]
    public async Task<IActionResult> Code(string code)
    {
        string codeVerifier = HttpContext.Session.GetString("codeVerifier");
        var redirectUrl = "http://localhost:5000/GoogleOAuth/api/oauth/code";

        
        var tokenResult= await _googleOAuth.ExchangeCodeOnToken(code, codeVerifier, redirectUrl);


        return Ok();
    }

}