using AutoMapper;
using Memo.Domain.Models;
using Memo.Api.ViewModels.User;

namespace Memo.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, LoginViewModel>().ReverseMap();
        CreateMap<User, RegisterViewModel>().ReverseMap();
    }
}