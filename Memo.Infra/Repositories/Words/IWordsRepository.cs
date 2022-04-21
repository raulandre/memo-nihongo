using Memo.Domain.Models;

namespace Memo.Infra.Repositories.Words;

public interface IWordsRepository
{
    Task<IList<Word>> Get(Guid userId);
    Task<Word> Add(Word word);
}