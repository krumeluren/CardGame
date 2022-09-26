﻿using Domain;

namespace CardGame.Data;

/// <summary>
/// Adapter for Card to be used in minigame with select events.
/// </summary>
public class MinigameCardHolder
{
    public Card Card { get; set; } = null!;
    public bool IsSelected { get; set; }

    public MinigameCardHolder(Card card)
    {
        Card = card;
    }
}
