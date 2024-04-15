using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services;

public class WeaponServiceTests {

    private readonly Mock<IGenericRepository<Weapon>> _mockRepo;

    public WeaponServiceTests()
    {
        _mockRepo = MockWeaponRepository.GetWeaponsMockRepository();
    }

    [Fact]
    public async Task GetAllAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object);
        var weapons = await _service.GetAllAsync();

        weapons.ShouldBeOfType<List<Weapon>>();
        weapons.Count.ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object);
        var weapon = await _service.GetByIdAsync(1);

        weapon.ShouldBeOfType<Weapon>();
        weapon.Id.ShouldBe(1);
        weapon.Name.ShouldBe("Test_weapon_1");
        weapon.WeekDays.ShouldBeOfType<string>();
    }
}


