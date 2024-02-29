using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class UserCharacterService : BaseHttpService, IUserCharacterService {
        public UserCharacterService(IClient client) : base(client) {

        }
    }
}
