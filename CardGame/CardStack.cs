
using Domain;
using Microsoft.AspNetCore.Components;
using Repository;
using ServiceContracts;
using Services;

namespace CardGame;

public class CardStack
{

    [Inject]
    private IServiceManager _services { get; set; } = null!;

    public IEnumerable<Card> Cards { get; set; } = new List<Card>();

    public CardStack(IServiceManager services)
    {
        _services = services;
    }

    public void CreateNewStack()
    {
        Cards = _services.CardService.GetAll();
    }

    public Card Random()
    {      
        var index = new Random().Next(Cards.Count());
        return Cards.ElementAt(index);
    }

}
