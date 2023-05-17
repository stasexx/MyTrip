namespace API.Services;

public interface IGoogleService
{
    public Task<string> GetEmail(string accessToken);
}