using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages.Characters
{
    public partial class List
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserCharacterService UserCharacterService { get; set; }

        public List<CharacterVM> UserCharacters { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
                .GetId();
            UserCharacters = await UserCharacterService.GetUserCharacters(userId);
        }
    }
}