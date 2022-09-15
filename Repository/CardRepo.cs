using Domain;
using RepositoryContracts;

namespace Repository;

public class CardRepo : RepoBase<Card>, ICardRepo
{

    public CardRepo(RepoContext repoContext) : base(repoContext)
    {}

    public IEnumerable<Card> GetAll() => FindAll().ToList();
    
}
