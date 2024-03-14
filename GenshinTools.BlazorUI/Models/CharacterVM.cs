using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class CharacterVM {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string WeekDays { get; set; }
}
