using Models;
using ServiceContracts;

namespace CardGame.Data;

/// <summary>
/// Minigame table model
/// </summary>
public class MinigameTable
{
    private IServiceManager _service { get; set; }
    private Table _table { get; set; }  
    public List<MinigameCardHolder> Deck { get; set; }
    public string PlayerName { get; set; }

    public MinigameTable(IServiceManager service)
    {
        _service = service;
        Deck = new List<MinigameCardHolder>();
        _table = new Table(_service);
    }

    public int CardCount() => _table.CardStack.Cards.Count;

    public int UsedCardCount() => _table.UsedCardsStack.Cards.Count;

    public void CreateCardStack() => _table.GenerateStack();

    public void SetPlayerName(string name) => PlayerName = name;

    public void ShuffleCardStack() => _table.CardStack.Shuffle();

    public void TakeCards(int count)
    {
        var cards = _table.Take(count);
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
                _table.Used(card.Card);
            }
        }
    }
}
