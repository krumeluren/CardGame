
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config;

/// <summary>
/// Card configuration for the dbcontext.
/// </summary>
internal class CardConfig : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasData
            (
            new Card { Id = 1, Suit = "Hearts", Number = "Ace" },
            new Card { Id = 2, Suit = "Hearts", Number = "Two" },
            new Card { Id = 3, Suit = "Hearts", Number = "Three" },
            new Card { Id = 4, Suit = "Hearts", Number = "Four" },
            new Card { Id = 5, Suit = "Hearts", Number = "Five" },
            new Card { Id = 6, Suit = "Hearts", Number = "Six" },
            new Card { Id = 7, Suit = "Hearts", Number = "Seven" },
            new Card { Id = 8, Suit = "Hearts", Number = "Eight" },
            new Card { Id = 9, Suit = "Hearts", Number = "Nine" },
            new Card { Id = 10, Suit = "Hearts", Number = "Ten" },
            new Card { Id = 11, Suit = "Hearts", Number = "Jack" },
            new Card { Id = 12, Suit = "Hearts", Number = "Queen" },
            new Card { Id = 13, Suit = "Hearts", Number = "King" },

            new Card { Id = 14, Suit = "Diamonds", Number = "Ace" },
            new Card { Id = 15, Suit = "Diamonds", Number = "Two" },
            new Card { Id = 16, Suit = "Diamonds", Number = "Three" },
            new Card { Id = 17, Suit = "Diamonds", Number = "Four" },
            new Card { Id = 18, Suit = "Diamonds", Number = "Five" },
            new Card { Id = 19, Suit = "Diamonds", Number = "Six" },
            new Card { Id = 20, Suit = "Diamonds", Number = "Seven" },
            new Card { Id = 21, Suit = "Diamonds", Number = "Eight" },
            new Card { Id = 22, Suit = "Diamonds", Number = "Nine" },
            new Card { Id = 23, Suit = "Diamonds", Number = "Ten" },
            new Card { Id = 24, Suit = "Diamonds", Number = "Jack" },
            new Card { Id = 25, Suit = "Diamonds", Number = "Queen" },
            new Card { Id = 26, Suit = "Diamonds", Number = "King" },

            new Card { Id = 27, Suit = "Spades", Number = "Ace" },
            new Card { Id = 28, Suit = "Spades", Number = "Two" },
            new Card { Id = 29, Suit = "Spades", Number = "Three" },
            new Card { Id = 30, Suit = "Spades", Number = "Four" },
            new Card { Id = 31, Suit = "Spades", Number = "Five" },
            new Card { Id = 32, Suit = "Spades", Number = "Six" },
            new Card { Id = 33, Suit = "Spades", Number = "Seven" },
            new Card { Id = 34, Suit = "Spades", Number = "Eight" },
            new Card { Id = 35, Suit = "Spades", Number = "Nine" },
            new Card { Id = 36, Suit = "Spades", Number = "Ten" },
            new Card { Id = 37, Suit = "Spades", Number = "Jack" },
            new Card { Id = 38, Suit = "Spades", Number = "Queen" },
            new Card { Id = 39, Suit = "Spades", Number = "King" },

            new Card { Id = 40, Suit = "Clubs", Number = "Ace" },
            new Card { Id = 41, Suit = "Clubs", Number = "Two" },
            new Card { Id = 42, Suit = "Clubs", Number = "Three" },
            new Card { Id = 43, Suit = "Clubs", Number = "Four" },
            new Card { Id = 44, Suit = "Clubs", Number = "Five" },
            new Card { Id = 45, Suit = "Clubs", Number = "Six" },
            new Card { Id = 46, Suit = "Clubs", Number = "Seven" },
            new Card { Id = 47, Suit = "Clubs", Number = "Eight" },
            new Card { Id = 48, Suit = "Clubs", Number = "Nine" },
            new Card { Id = 49, Suit = "Clubs", Number = "Ten" },
            new Card { Id = 50, Suit = "Clubs", Number = "Jack" },
            new Card { Id = 51, Suit = "Clubs", Number = "Queen" },
            new Card { Id = 52, Suit = "Clubs", Number = "King" }

            );
    }
}
