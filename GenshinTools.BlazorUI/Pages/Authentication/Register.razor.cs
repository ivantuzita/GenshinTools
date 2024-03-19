using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace GenshinTools.BlazorUI.Pages.Authentication
{
    public partial class Register
    {
        public UserVM Model { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }
        public string PasswordConfirm { get; set; }
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected async Task HandleRegister() {
            if (PasswordConfirm != Model.Password) {
                Message = "Your password does not match.";
            }
            else {
                var result = await AuthenticationService.RegisterAsync(Model.Username,
               Model.Password);
                if (result) {
                    NavigationManager.NavigateTo("/");
                }
                Message = "Something went wrong, please try again.";
            }
        }

        protected override void OnInitialized()
        {
            Model = new UserVM();
        }
    }
}