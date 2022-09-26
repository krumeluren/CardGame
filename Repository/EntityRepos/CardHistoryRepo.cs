using Domain;
using RepositoryContracts;

namespace Repository.EntityRepos;

public class CardHistoryRepo : RepoBase<CardHistory>, ICardHistoryRepo
{
    public CardHistoryRepo(RepoContext repoContext) : base(repoContext)
    {
    }

    public void Add(CardHistory cardHistory) => Create(cardHistory);
    

    public IEnumerable<CardHistory> GetAll() => FindAll().ToList();
    
}
