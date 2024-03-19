using GenshinTools.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace GenshinTools.BlazorUI.Pages.Components; 
public partial class CharCard {
    [Parameter]
    public string Name { get; set; }
    [Parameter]
    public string PictureURL { get; set; }

    public string Message { get; set; } = string.Empty;
}