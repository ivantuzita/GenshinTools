using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class UserService : BaseHttpService, IUserService {
        public UserService(IClient client) : base(client) {

        }
    }
}
