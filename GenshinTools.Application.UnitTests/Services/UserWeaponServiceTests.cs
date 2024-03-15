using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Application.UnitTests.Mocks;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services;

public class UserWeaponServiceTests {

    private readonly Mock<IUserWeaponRepository> _mockRepo;
    private readonly Mock<IGenericRepository<Weapon>> _weaponMockRepo;
    private readonly Mock<IGenericRepository<AuthRequest>> _userMockRepo;

    public UserWeaponServiceTests() {
        _mockRepo = MockUserWeaponRepository.GetUserWeaponMockRepository();
        _weaponMockRepo = MockWeaponRepository.GetWeaponsMockRepository();
        _userMockRepo = MockUserRepository.GetUserMockRepository();
    }

    [Fact]
    public async Task GetUserWeaponsTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object, _userMockRepo.Object);
        var weapons = await _service.GetUserWeapons(1);

        weapons.Count.ShouldBe(2);
        weapons.ShouldBeOfType<List<Weapon>>();
    }

    [Fact]
    public async Task GetUserWeaponsFilteredTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object, _userMockRepo.Object);
        var weapons = await _service.GetUserWeaponsFiltered(1);

        //only charId 2 fits
        weapons.Count.ShouldBe(1);
        weapons.ShouldBeOfType<List<Weapon>>();
    }


    [Fact]
    public async Task AssociateWeaponToUserTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object, _userMockRepo.Object);
        await _service.AssociateWeaponToUser(1, 3);

        var list = await _service.GetUserWeapons(1);
        var result = list.FirstOrDefault(x => x.Id == 3);

        result.ShouldBeOfType<Weapon>();
        result.Id.ShouldBe(3);
        result.Name.ShouldBe("test_weapon_3");
        result.WeekDays.ShouldBeOfType<List<int>>();
    }

    [Fact]
    public async Task DiassociateWeaponToUserTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object, _userMockRepo.Object);
        await _service.DisassociateWeaponToUser(1, 2);

        var list = await _service.GetUserWeapons(1);

        list.Count.ShouldBe(1);
    }
}
