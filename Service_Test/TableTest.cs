

using Domain;
using Models;
using Moq;
using ServiceContracts;

namespace Service_Test;

public class TableTest 
{
    private readonly Table _table;
    private readonly Mock<IServiceManager> _serviceManagerMock;
    private readonly Mock<ICardStack> _cardStackMock;
    private readonly Mock<ICardStack> _usedCardsStackMock;

    public TableTest()
    {
        _serviceManagerMock = new Mock<IServiceManager>();
        _table = new Table(_serviceManagerMock.Object);
        _cardStackMock = new Mock<ICardStack>();
        _usedCardsStackMock = new Mock<ICardStack>();
    }

    [Fact]
    public List<Card> GenerateStack_ShouldAddDbCardsToCardStack()
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
        _table.GenerateStack();
        
        var actual = _table.CardStack.Cards;

        //Assert
        Assert.Equal(dbCards, actual);

        return _table.CardStack.Cards.ToList();

    }

    [Fact]
    public List<Card> Take_ReturnEmpty_WhenCount_IsNegative()
    {
        //Arrange
        int count = -10;

        _table.CardStack.Cards = new List<Card>()
        {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 }
        };

        _cardStackMock.Setup(x => x.TakeFrom(count))
            .Returns(new List<Card>());
        
        _serviceManagerMock.Setup(x => x.CardStackService
        .GetLastCards(_table.CardStack.Cards, count))
            .Returns(new List<Card>());

        //Act
        var returnedCards = _table.Take(count);

        //Assert
        Assert.Empty(returnedCards);

        return returnedCards.ToList();
    }
    [Fact]
    public List<Card> Take_ShouldReturnCOUNTCards_WhenCardsAre_LessThanCOUNT_But_Greater_ThanTotalCards()
    {
        //Arrange
        int count = 9;

        _table.CardStack.Cards = new List<Card>()
        {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 }
        };
        _table.UsedCardsStack.Cards = new List<Card>()
        {
            new Card() { Id = 6 },
            new Card() { Id = 7 },
            new Card() { Id = 8 },
            new Card() { Id = 9 },
            new Card() { Id = 10 }
        };

        var expected = _table.CardStack.Cards.Concat(_table.UsedCardsStack.Cards).ToList();
        expected.Remove(expected[0]);

        _cardStackMock.Setup(x => x.TakeFrom(count)).Returns(() => expected.ToList());
        
        _serviceManagerMock.Setup(x => x.CardStackService
        .GetLastCards(It.IsAny<List<Card>>(), count)).Returns(() => expected);

        //Act

        var actual = _table.Take(count).OrderBy(x => x.Id).ToList();

        //Assert
        Assert.Equal(expected, actual);

        return actual.ToList();
    }

    [Fact]
    public List<Card> Take_ShouldReturnEmpty_WhenCOUNT_IsHigherThanTotalCards()
    {
        //Arrange
        int count = 11;

        _table.CardStack.Cards = new List<Card>()
        {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 }
        };
        _table.UsedCardsStack.Cards = new List<Card>()
        {
            new Card() { Id = 6 },
            new Card() { Id = 7 },
            new Card() { Id = 8 },
            new Card() { Id = 9 },
            new Card() { Id = 10 }
        };

        //Act
        var actual = _table.Take(count).OrderBy(x => x.Id).ToList();

        //Assert
        Assert.Empty(actual);

        return actual.ToList();
    }

    [Fact]
    public void Used_AddsCardToUsedCardsStack()
    {
        //Arrange
        var card = new Card() { Id = 1 };

        _table.UsedCardsStack.Cards = new List<Card>();

        //Act
        _table.Used(card);

        //Assert
        Assert.Contains(card, _table.UsedCardsStack.Cards);
    }
}
