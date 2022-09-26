using Domain;

namespace RepositoryContracts;

public interface IPlayerRepo
{
    public Player GetByName(string name);

    public void Add(Player player);
}
