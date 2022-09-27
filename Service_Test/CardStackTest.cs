using Domain;
using Moq;
using RepositoryContracts;
using Services;

namespace Service_Test;

public class CardStackTest
{

    private readonly CardStackService _cardStack_UnderTest;
    private readonly Mock<IRepoManager> _repoManagerMock = new Mock<IRepoManager>();
    public CardStackTest()
    {
        _cardStack_UnderTest = new CardStackService(_repoManagerMock.Object);
    }


    [Fact]
    public List<Card> Shuffle_ShouldReturnAListOfSameItems()
    {
        //Arrange
        var CardStack = new CardStackService(_repoManagerMock.Object);

        var cards = new List<Card>() {
            new Card() { Id = 1 },
            new Card() { Id = 2 },
            new Card() { Id = 3 },
            new Card() { Id = 4 },
            new Card() { Id = 5 },
            new Card() { Id = 6 },
            new Card() { Id = 7 },
            new Card() { Id = 8 },
            new Card() { Id = 9 },
            new Card() { Id = 10 }
        };

        var expected = cards.OrderBy(x => x.Id).ToList();

        //Act
        var actual = CardStack.Shuffle(cards).OrderBy(x => x.Id).ToList();

        //Assert

        Assert.Equal(expected, actual);
        return actual.ToList();

    }
}