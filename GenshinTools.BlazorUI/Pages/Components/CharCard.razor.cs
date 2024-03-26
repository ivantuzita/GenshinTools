using GenshinTools.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace GenshinTools.BlazorUI.Pages.Components;
public partial class CharCard
{
    [Parameter]
    public int Id { get; set; }
    [Parameter]
    public string Name { get; set; }
    [Parameter]
    public string PictureURL { get; set; }
    [Parameter]
    public string LocationURL { get; set; }
    [Parameter]
    public string Material { get; set; }
    [Parameter]
    public string MaterialURL { get; set; }
    [Parameter]
    public int Quality { get; set; }
    [Parameter]
    public EventCallback<int> OnDone { get; set; }
    [Parameter]
    public string ButtonClass { get; set; }
    public string Stars { get; set; }

    private string SetStars()
    {
        for (int i = 0; i < Quality; i++)
        {
            Stars += "⭐";
        }
        return Stars;
    }

    protected async Task DoneClick() {
        await OnDone.InvokeAsync(Id);
    }

    protected async override Task OnInitializedAsync()
    {
        SetStars();
    }
}