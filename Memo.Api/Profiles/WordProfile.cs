using AutoMapper;
using Memo.Api.ViewModels.Words;
using Memo.Domain.Models;

namespace Memo.Api.Profiles;

public class WordProfile : Profile
{
    public WordProfile()
    {
        CreateMap<Word, CreateWordViewModel>().ReverseMap();
        CreateMap<Word, UpdateWordViewModel>().ReverseMap();
    }
}