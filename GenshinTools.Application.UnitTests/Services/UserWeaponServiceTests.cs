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

    public UserWeaponServiceTests() {
        _mockRepo = MockUserWeaponRepository.GetUserWeaponMockRepository();
        _weaponMockRepo = MockWeaponRepository.GetWeaponsMockRepository();
    }

    [Fact]
    public async Task GetUserWeaponsTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object);
        var weapons = await _service.GetUserWeapons("lorem_ipsum");

        weapons.Count.ShouldBe(2);
        weapons.ShouldBeOfType<List<Weapon>>();
    }

    [Fact]
    public async Task GetUserWeaponsFilteredTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object);
        var weapons = await _service.GetUserWeaponsFiltered("lorem_ipsum");

        //only charId 2 fits
        weapons.Count.ShouldBe(1);
        weapons.ShouldBeOfType<List<Weapon>>();
    }


    [Fact]
    public async Task AssociateWeaponToUserTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object);
        await _service.AssociateWeaponToUser("lorem_ipsum", 3);

        var list = await _service.GetUserWeapons("lorem_ipsum");
        var result = list.FirstOrDefault(x => x.Id == 3);

        result.ShouldBeOfType<Weapon>();
        result.Id.ShouldBe(3);
        result.Name.ShouldBe("test_weapon_3");
        result.WeekDays.ShouldBeOfType<string>();
    }

    [Fact]
    public async Task DiassociateWeaponToUserTest() {
        var _service = new UserWeaponService(_mockRepo.Object, _weaponMockRepo.Object);
        await _service.DisassociateWeaponToUser("lorem_ipsum", 2);

        var list = await _service.GetUserWeapons("lorem_ipsum");

        list.Count.ShouldBe(1);
    }
}
