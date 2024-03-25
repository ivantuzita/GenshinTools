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
        [Inject]
        public ICharacterService CharacterService { get; set; }
        protected string userId { get; set; }

        public List<CharacterVM> UserCharacters { get; private set; }
        public List<CharacterVM> Characters { get; private set; }

        public string Message { get; set; } = string.Empty;

        protected async Task AssociateCharacter(int charId) {
            var response = await UserCharacterService.AssociateCharacterToUser(userId, charId);
            if (response.Success)
            {
                NavigationManager.Refresh();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected async Task DisassociateCharacter(int charId) {
            var response = await UserCharacterService.DisassociateCharacterToUser(userId, charId);
            if (response.Success)
            {
                NavigationManager.Refresh();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected List<CharacterVM> CharactersYouDontOwn(List<CharacterVM> userchars, List<CharacterVM> chars) {
            var result = chars.Where(p => !userchars.Any(p2 => p2.Id == p.Id)).ToList();
            return result;
        }

        protected override async Task OnInitializedAsync()
        {
            userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetId();
            UserCharacters = await UserCharacterService.GetUserCharacters(userId);
            Characters = CharactersYouDontOwn(UserCharacters, await CharacterService.GetAllCharactersAsync());
        }
    }
}