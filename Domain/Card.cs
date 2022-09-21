
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Card
{
    public int Id { get; set; }
    public string Suit { get; set; }
    public string Number { get; set; }
}
