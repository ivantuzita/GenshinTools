using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class WeaponVM {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    [Required]
    public List<int> WeekDays { get; set; }
}
