using Domain;
using RepositoryContracts;

namespace Repository.EntityRepos;

public class PlayerRepo : RepoBase<Player>, IPlayerRepo
{
    public PlayerRepo(RepoContext repoContext) : base(repoContext)
    { }

    public void Add(Player player) => Create(player);

    public Player GetByName(string name)
    {
        return FindByCondition(p => p.Name == name).FirstOrDefault();
    }
}
