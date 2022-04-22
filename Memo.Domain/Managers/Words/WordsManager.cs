using Memo.Domain.Models;
using Memo.Domain.Repositories;

namespace Memo.Domain.Managers.Words;

public class WordsManager : IWordsManager
{
    private readonly IWordsRepository wordRepository;

    public WordsManager(IWordsRepository wordsRepository)
    {
       wordRepository = wordsRepository; 
    }

    public async Task<Word> Create(Word word)
        => await wordRepository.Add(word);

    public async Task<bool> Delete(Guid id)
    {
        var word = await wordRepository.Get(id);

        if(word is not null)
        {
            await wordRepository.Delete(word);
            return true;
        }

        return false;
    }

    public async Task<List<Word>> GetByUser(Guid userId)
        => await wordRepository.GetByUserId(userId);

    public async Task<Word> Update(Word word)
    {
        word.LastReviewed = DateTime.UtcNow;
        return await wordRepository.Update(word);
    }
}