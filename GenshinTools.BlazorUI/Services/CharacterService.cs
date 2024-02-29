using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class CharacterService : BaseHttpService, ICharacterService {
        public CharacterService(IClient client) : base(client) {

        }
    }
}
