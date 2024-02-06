﻿namespace GenshinTools.Application.DTOs; 
public class WeaponDTO {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<int> WeekDays { get; set; } = new List<int>();
}