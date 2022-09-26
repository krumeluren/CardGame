using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Player
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
