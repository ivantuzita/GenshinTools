﻿using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class WeaponVM {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string WeekDays { get; set; }
    public string PictureURL { get; set; }
    public int Quality { get; set; }
    //separated by comma
    public string TalentMaterial { get; set; }
    public string TalentMaterialPictureURL { get; set; }
    //separated by semicolon
    public string DomainLocationURL { get; set; }
}
