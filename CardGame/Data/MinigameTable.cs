using Models;
using ServiceContracts;

namespace CardGame.Data;

public class MinigameTable
{
    private IServiceManager _service { get; set; }
    private CardStack CardStack { get; set; }
    public List<MinigameCardHolder> Deck { get; set; }
    public string PlayerName { get; set; }

    public int UsedCardsCount
    {
        get { return CardStack.UsedCards.Count(); }
        set { UsedCardsCount = CardStack.UsedCards.Count(); }
    }

    public int CardsCount
    {
        get { return CardStack.Cards.Count(); }
        set { CardsCount = CardStack.Cards.Count(); }
    }

    public MinigameTable(IServiceManager service)
    {
        _service = service;
        Deck = new List<MinigameCardHolder>();
        CardStack = new CardStack(_service);
    }

    public void CreateCardStack() => CardStack.GenerateStack();

    public void SetPlayerName(string name) => PlayerName = name;

    public void ShuffleCardStack() => CardStack.Shuffle();


    public void TakeCards(int count)
    {
        var cards = CardStack.Take(count);
        foreach (var card in cards)
        {
            _service.PlayerService.AddCardHistory(PlayerName, card);
            Deck.Add(new MinigameCardHolder(card));
        }
    }

    public void ReplaceCards()
    {
        var cardsToReplace = Deck.Where(x => x.IsSelected).ToList();
        foreach (var card in cardsToReplace)
        {
            if (Deck.Remove(card))
            {
                TakeCards(1);
                CardStack.AddToUsedCards(card.Card);
            }
        }
    }


}
