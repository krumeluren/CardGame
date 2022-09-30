namespace ServiceContracts;

/// <summary>
/// This interface is used to implement and access all services.
/// </summary>
public interface IServiceManager
{
    ICardStackService CardStackService { get; }
    IPlayerService PlayerService { get; }
}
