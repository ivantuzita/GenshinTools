using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Application.MappingProfiles;
using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services;

public class WeaponServiceTests {

    private readonly Mock<IGenericRepository<Weapon>> _mockRepo;
    private IMapper _mapper;

    public WeaponServiceTests()
    {
        _mockRepo = MockWeaponRepository.GetWeaponsMockRepository();
        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<WeaponProfile>(); });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAllAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object, _mapper);
        var weapons = await _service.GetAllAsync();

        weapons.ShouldBeOfType<List<Weapon>>();
        weapons.Count.ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object, _mapper);
        var weapon = await _service.GetByIdAsync(1);

        weapon.ShouldBeOfType<Weapon>();
        weapon.Id.ShouldBe(1);
        weapon.Name.ShouldBe("Test_weapon_1");
        weapon.WeekDays.ShouldBeOfType<List<int>>();
    }

    [Fact]
    public async Task DeleteByIdTest()
    {
        var _service = new WeaponService(_mockRepo.Object, _mapper);

        var getAll = await _service.GetAllAsync();

        await _service.DeleteByIdAsync(3);

        getAll.Count.ShouldBe(2);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object, _mapper);
        var weaponDTO = new WeaponDTO
        {
            Name = "Test_Weapon_4",
            WeekDays = new List<int> { 0, 2 }
        };

        await _service.CreateAsync(weaponDTO);

        var weapons = await _service.GetAllAsync();

        weapons.ShouldBeOfType<List<Weapon>>();
        weapons.Count.ShouldBe(4);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var _service = new WeaponService(_mockRepo.Object, _mapper);
        var weapon = new WeaponDTO { Id = 1, Name = "Test_Weapon_replacement" };

        await _service.UpdateAsync(weapon);

        var updated = await _service.GetByIdAsync(1);

        updated.ShouldBeOfType<Weapon>();
        updated.Id.ShouldBe(1);
        updated.Name.ShouldBe("Test_Weapon_replacement");
        updated.WeekDays.ShouldBeOfType<List<int>>();
    }
}


