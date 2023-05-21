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
    
    private readonly IGoogleService _google;

    private readonly IUserService _userService;
    
    public GoogleOAuthController(IGoogleOAuthService googleOAuth, IGoogleService google, IUserService userService)
    {
        _googleOAuth = googleOAuth;
        _google = google;
        _userService = userService;
    }
    
    [HttpGet("oauth/authorization")]
    public IActionResult RedirectOnOAuthServer()
    {
        var scope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
        var redirectUrl = "http://localhost:5000/api/GoogleOAuth/oauth/authorization/code";

        var codeVerifier = Guid.NewGuid().ToString();
        HttpContext.Session.SetString("codeVerifier", codeVerifier);
        var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);
        var url = _googleOAuth.GenerateOAuthRequestUrl(scope, redirectUrl, codeChallenge);
        return Redirect(url);
    }
    
    [HttpGet("oauth/authorization/code")]
    public async Task<IActionResult> Code(string code)
    {
        string codeVerifier = HttpContext.Session.GetString("codeVerifier");
        var redirectUrl = "http://localhost:5000/api/GoogleOAuth/oauth/authorization/code";
        
        var tokenResult= await _googleOAuth.ExchangeCodeOnToken(code, codeVerifier, redirectUrl);
        var dateForReg = _google.GetGmailUserInfo(tokenResult.AccessToken);
        _userService.AuthorizationWithOAut(dateForReg.Result.Email, dateForReg.Result.picture,
            dateForReg.Result.Name.Split(" ")[0], dateForReg.Result.Name.Split(" ")[1]);
        return Ok();
    }
    
    

}