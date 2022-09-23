using Domain;
using Microsoft.AspNetCore.Components;
using ServiceContracts;

namespace CardGame.Data;

public class CardStack
{
    private IServiceManager _services { get; set; } = null!;

    public List<Card> Cards { get; set; } = new List<Card>();

    public CardStack(IServiceManager services)
    {
        _services = services;
    }

    public void GenerateStack()
    {
        Cards = _services.CardService.GetAll().ToList();
    }

    public List<Card> TakeRandom(int count = 1)
    {
        var cardsToTake = new List<Card>();
        if(Cards.Count < count)
        GenerateStack();
        
        for (int i = 0; i < count; i++)
        {
            var index = new Random().Next(Cards.Count());
            var card = Cards[index];
            cardsToTake.Add(card);
            Cards.Remove(card);
        }
        return cardsToTake;
    }

}
