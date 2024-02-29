using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class WeaponService : BaseHttpService, IWeaponService {
        public WeaponService(IClient client) : base(client) {

        }
    }
}
