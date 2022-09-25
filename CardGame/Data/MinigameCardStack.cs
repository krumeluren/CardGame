using Domain;
using ServiceContracts;


namespace CardGame.Data;

public class MinigameCardStack
{
    public List<Card> Cards { get; set; }
    
    public IServiceManager service { get; set; }

    public MinigameCardStack(IServiceManager serviceManager)
    {
        service = serviceManager;
    }
    public void GenerateStack()
    {
        Cards = service.CardStackService.GenerateStack();
    }
    
    public void Shuffle()
    {
        Cards = service.CardStackService.Shuffle(Cards);
    }

    public List<Card> Take(int count = 1)
    {
        if (Cards.Count < count)
        {
            GenerateStack();
            Shuffle();
        }
        return service.CardStackService.Take(Cards, count);
    }
}
