﻿using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Player
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
