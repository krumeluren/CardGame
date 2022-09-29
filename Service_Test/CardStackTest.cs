using Domain;
using Models;
using Moq;
using ServiceContracts;
using Services;

namespace Service_Test;

public class CardStackTest
{
    private readonly CardStack _cardStack;
    private readonly Mock<IServiceManager> _serviceManagerMock;

    public CardStackTest()
    {
        _serviceManagerMock = new Mock<IServiceManager>(); 
        _cardStack = new CardStack(_serviceManagerMock.Object);
    }

    [Fact]
    public List<Card> TakeFrom_CardsShouldNotContainReturnedCards()
    {

        //Arrange
        int count = 3;

        _cardStack.Cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };
        _serviceManagerMock.Setup(x => x.CardStackService.GetLastCards(_cardStack.Cards, count))
            .Returns(new List<Card>() { _cardStack.Cards[1],  });
                
        
        //Act
        var returnedCards = _cardStack.TakeFrom(count);

        //Assert
        Assert.DoesNotContain(_cardStack.Cards, c => returnedCards.Contains(c));

        return returnedCards.ToList();
    }

    [Fact]
    public List<Card> TakeFrom_NegativeCount_ShouldReturnEmpty()
    {

        //Arrange
        int count = -10;

        _cardStack.Cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };
        _serviceManagerMock.Setup(x => x.CardStackService.GetLastCards(_cardStack.Cards, count))
            .Returns(new List<Card>());


        //Act
        var returnedCards = _cardStack.TakeFrom(count);

        //Assert
        Assert.Empty(returnedCards);

        return returnedCards.ToList();
    }
    
    [Fact]
    public void TakeFrom_WhenReturnListIsEmpty_ShouldNotRemoveFromCards()
    {

        //Arrange
        int count = 3;

        _cardStack.Cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };
        
        _serviceManagerMock.Setup(x => x.CardStackService.GetLastCards(_cardStack.Cards, count))
            .Returns(new List<Card>());

        //Act
        _cardStack.TakeFrom(count);

        //Assert
        Assert.True(_cardStack.Cards.Count == 5);
    }

    [Fact]
    public void TakeFrom_WhenCount_IsGreaterThan_CardsCount_ShouldReturnEmpty()
    {

        //Arrange
        int count = 10;

        _cardStack.Cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };

        _serviceManagerMock.Setup(x => x.CardStackService.GetLastCards(_cardStack.Cards, count));
            

        //Act
        var returnedCards = _cardStack.TakeFrom(count);

        //Assert
        Assert.Empty(returnedCards);
    }

    [Fact]
    public void GenerateStack_CardsEqualGenerateStackReturnValue()
    {

        //Arrange
        var dbCards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };

        _serviceManagerMock.Setup(x => x.CardStackService.GenerateStack())
            .Returns(dbCards);

        //Act
        _cardStack.GenerateStack();

        //Assert
        Assert.Equal(dbCards, _cardStack.Cards);
    }

    [Fact]
    public void Shuffle_CardsEqualShuffledCards()
    {
        //Arrange
        var cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };

        _cardStack.Cards = cards.ToList();

        var expected = cards.OrderBy(c => c.Id).ToList();

        //Act
        _cardStack.Shuffle();

        var actual = _cardStack.Cards.OrderBy(c => c.Id).ToList();

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AddTo_UsedCardIsAddedToCards()
    {
        //Arrange
        var card = new Card() { Id = 1 };

        //Act
        _cardStack.AddTo(card);

        //Assert
        Assert.Contains(card, _cardStack.Cards);
    }
}
