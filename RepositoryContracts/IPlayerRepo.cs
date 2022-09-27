using Domain;

namespace RepositoryContracts;

public interface IPlayerRepo
{
    Player GetByName(string name);

    void Add(Player player);
}
