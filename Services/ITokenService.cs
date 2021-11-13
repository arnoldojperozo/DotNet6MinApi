namespace DotNet6MinApi.Services;
public interface ITokenService
{
    string GetToken(DbUser user);
}

