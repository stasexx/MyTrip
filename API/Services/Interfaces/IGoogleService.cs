namespace API.Services;

public interface IGoogleService
{
    public Task<GmailUserInfo> GetGmailUserInfo(string accessToken);
}