namespace DotNet6MinApi.Models;

public class MinApiDemoMapper : Profile
{
    public MinApiDemoMapper(IDataProtector provider)
    {
        CreateMap<DbUser, User>()
        .ForMember(u => u.FullName, opt => opt.MapFrom(u2 => u2.Name + " " + u2.LastName))
        .ForMember(u => u.PasswordHash, opt => opt.MapFrom(u2 => provider.Unprotect(u2.PasswordHash)));
        CreateMap<User, DbUser>().ForMember(u => u.PasswordHash, opt => opt.MapFrom(u2 => provider.Protect(u2.Password)));
    }
}