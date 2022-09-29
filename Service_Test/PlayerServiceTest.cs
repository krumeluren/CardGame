
using Domain;
using Models;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;
using System.Numerics;

namespace Service_Test;

public class PlayerServiceTest
{

    private readonly Mock<IRepoManager> _repoManagerMock;
    private readonly PlayerService _playerService;
    public PlayerServiceTest()
    {
        _repoManagerMock = new Mock<IRepoManager>();
        _playerService = new PlayerService(_repoManagerMock.Object);
    }

    [Fact]
    public Player? GetPlayerByName_IfPlayerExists_ReturnsPlayerFromDb()
    {
        //Arrange
        var playerName = "Player1";
        var Player = new Player() { Name = playerName };

        _repoManagerMock.Setup(x => x.Players.GetByName(playerName)).Returns(Player);

        var expected = Player;

        //Act
        var actual = _playerService.GetPlayerByName(playerName);

        //Assert
        Assert.NotNull(actual);

        return actual;
    }

    [Fact]
    public Player? GetPlayerByName_IfPlayerNotExist_ReturnsNull()
    {
        //Arrange
        var playerName = "Player1";

        _repoManagerMock.Setup(x => x.Players.GetByName(playerName));

        //Act
        var actual = _playerService.GetPlayerByName(playerName);

        //Assert
        Assert.Null(actual);

        return actual;
    }

    [Fact]
    public List<CardHistory> GetAllHistory_IfPlayerNotExist_ShouldReturnEmptyList()
    {
        //Arrange
        var playerName = "Player1";
        var invalidList = new List<CardHistory>() 
        {
            new CardHistory() { CardId = 1, PlayerId = 2 },
            new CardHistory() { CardId = 2, PlayerId = 2 },
            new CardHistory() { CardId = 3, PlayerId = 2 },
            new CardHistory() { CardId = 4, PlayerId = 2 },
            new CardHistory() { CardId = 5, PlayerId = 2 },
        };

        _repoManagerMock.Setup(x => x.Players.GetByName(playerName)).Returns((Player?)null);
        
        _repoManagerMock.Setup(x => x.PlayerCardHistory.GetAll()).Returns(invalidList);

        var expected = new List<CardHistory>();

        //Act
        var actual = _playerService.GetAllHistory(playerName);

        //Assert
        Assert.Empty(actual);

        return actual;
    }

    [Fact]
    public List<CardHistory> GetAllHistory_IfPlayerExist_ShouldReturnCardHistoriesBelongingToPlayer()
    {
        //Arrange
        var playerName = "Player1";
        var cardHistories = new List<CardHistory>()
        {
            new CardHistory() { CardId = 1, PlayerId = 1 },
            new CardHistory() { CardId = 2, PlayerId = 1 },
            new CardHistory() { CardId = 3, PlayerId = 1 },
            new CardHistory() { CardId = 4, PlayerId = 2 },
            new CardHistory() { CardId = 5, PlayerId = 2 },
        };
        var player = new Player() { Name = playerName, Id = 1 };

        _repoManagerMock.Setup(x => x.PlayerCardHistory.GetAll()).Returns(cardHistories);
        _repoManagerMock.Setup(x => x.Players.GetByName(playerName)).Returns(player);

        var expected = cardHistories.Where(x => x.PlayerId == player.Id).ToList();

        //Act
        var actual = _playerService.GetAllHistory(playerName);

        //Assert
        Assert.Equal(expected, actual);

        return actual;
    }

    [Fact]
    public void AddCardHistory_IfPlayerNameIsNull_DidNotSave()
    {
        //Arrange
        var playerName = (string?)null;
        var card = new Card() { Id = 1 };

        //Act
        _playerService.AddCardHistory(playerName, card);

        //Assert
        
        _repoManagerMock.Verify(x => x.Save(), Times.Never);
    }

    [Fact]
    public void AddCardHistory_IfPlayerNotExist_CreateAddAndSave()
    {
        //Arrange
        var playerName = "Player1";
        var card = new Card() { Id = 1 };

        _repoManagerMock.Setup(x => x.Players.GetByName(playerName)).Returns((Player?)null);
        _repoManagerMock.Setup(x => x.PlayerCardHistory.Add(new CardHistory() { CardId = 1, PlayerId = 1 }));

        //Act
        _playerService.AddCardHistory(playerName, card);

        //Assert
        _repoManagerMock.Verify(x => x.Players.Add(It.IsAny<Player>()), Times.Once);
        _repoManagerMock.Verify(x => x.PlayerCardHistory.Add(It.IsAny<CardHistory>()), Times.Once);
        _repoManagerMock.Verify(x => x.Save(), Times.Exactly(2));
    }

    [Fact]
    public void AddCardHistory_IfPlayerExist_AddAndSave()
    {

        //Arrange
        var playerName = "Player1";
        var card = new Card() { Id = 1 };
        var player = new Player() { Name = playerName, Id = 1 };

        _repoManagerMock.Setup(x => x.Players.GetByName(playerName)).Returns(player);
        _repoManagerMock.Setup(x => x.PlayerCardHistory.Add(new CardHistory() { CardId = 1, PlayerId = 1 }));

        //Act
        _playerService.AddCardHistory(playerName, card);

        //Assert
        _repoManagerMock.Verify(x => x.Players.Add(It.IsAny<Player>()), Times.Never);
        _repoManagerMock.Verify(x => x.PlayerCardHistory.Add(It.IsAny<CardHistory>()), Times.Once);
        _repoManagerMock.Verify(x => x.Save(), Times.Once);
    }
}
