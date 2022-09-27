namespace ServiceContracts;

public interface IServiceManager
{
    ICardStackService CardStackService { get; }
    IPlayerService PlayerService { get; }
}
