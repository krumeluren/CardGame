using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Player
{
    [Key]
    int Id { get; set; }
    string Name { get; set; }
}
