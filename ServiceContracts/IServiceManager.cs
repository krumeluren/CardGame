namespace ServiceContracts;

public interface IServiceManager
{
    ICardStack CardStackService { get; }
    IPlayerService PlayerService { get; }
}
