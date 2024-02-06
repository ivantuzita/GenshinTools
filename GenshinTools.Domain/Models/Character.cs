﻿using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models;
public class Character {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    public List<int> WeekDays { get; set; }
}