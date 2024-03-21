using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages.Characters
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IUserCharacterService UserCharacterService { get; set; }

        public List<CharacterVM> Characters { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
            .GetId();
            Characters = await UserCharacterService.GetUserCharactersFiltered(userId);
        }
    }

}