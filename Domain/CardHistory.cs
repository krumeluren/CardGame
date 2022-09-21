
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class CardHistory
{
    public int Id { get; set; }
    
    [ForeignKey("Card")]
    public int CardId { get; set; }
    public Card Card { get; set; }

    [ForeignKey("Player")]
    public int PlayerId { get; set; }
    public Player Player { get; set; }
}
