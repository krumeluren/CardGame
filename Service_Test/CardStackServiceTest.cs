using Domain;
using Moq;
using RepositoryContracts;
using Services;

namespace Service_Test;

public class CardStackServiceTest
{

    private readonly CardStackService _cardStackService;
    private readonly Mock<IRepoManager> _repoManagerMock;
    public CardStackServiceTest()
    {
        _repoManagerMock = new Mock<IRepoManager>();
        _cardStackService = new CardStackService(_repoManagerMock.Object);
    }

    [Fact]
    public List<Card> GetLastCards_EmptyListWithCountShouldReturnEmpty()
    {
        //Arrange
        var cards = new List<Card>();

        //Act
        var expected = _cardStackService.GetLastCards(cards, 5);

        //Assert
        Assert.Empty(expected);
        
        return expected.ToList();
    }

    [Fact]
    public List<Card> GetLastCards_WhenCardsCountIsSmallerThanCount_ShouldReturnEmpty()
    {
        //Arrange
        var cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };

        //Act
        var expected = _cardStackService.GetLastCards(cards, 24);

        //Assert
        Assert.Empty(expected);

        return expected.ToList();
    }

    [Fact]
    public List<Card> GetLastCards_WhenCountIsNegative_ShouldReturnEmpty()
    {
        //Arrange
        var cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };

        //Act
        var expected = _cardStackService.GetLastCards(cards, -10);

        //Assert
        Assert.Empty(expected);

        return expected.ToList();
    }
    [Fact]
    public List<Card> GetLastCards_ShouldNotRemoveItemsFromParameterList()
    {
        //Arrange
        var cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            };
        
        var expected = cards.ToList();

        //Act
        _cardStackService.GetLastCards(cards, 3);

        var actual = cards.ToList();

        //Assert
        Assert.Equal(expected, actual);

        return expected.ToList();
    }
}
