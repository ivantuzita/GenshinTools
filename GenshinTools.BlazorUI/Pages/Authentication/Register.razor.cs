using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace GenshinTools.BlazorUI.Pages.Authentication
{
    public partial class Register
    {
        public UserVM Model { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected async Task HandleRegister() {
            var result = await AuthenticationService.RegisterAsync(Model.Username,
               Model.Password);
            if (result) {
                NavigationManager.NavigateTo("/");
            }
            Message = "Something went wrong, please try again.";
        }

        protected override void OnInitialized()
        {
            Model = new UserVM();
        }
    }
}