using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class UserWeaponService : BaseHttpService, IUserWeaponService {
    public UserWeaponService(IClient client) : base(client) {

    }
}
}
