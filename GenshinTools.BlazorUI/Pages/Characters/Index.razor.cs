using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace GenshinTools.BlazorUI.Pages.Characters
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICharacterService CharacterService { get; set; }

        public List<CharacterVM> Characters { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Characters = await CharacterService.GetAllCharactersAsync();
        }
    }

}