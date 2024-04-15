using AutoMapper;
using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services; 
public class CharacterServiceTests {

    private readonly Mock<IGenericRepository<Character>> _mockRepo;

    public CharacterServiceTests()
    {
        _mockRepo = MockCharacterRepository.GetCharactersMockRepository();
    }

    [Fact]
    public async Task GetAllAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object);
        var chars = await _service.GetAllAsync();

        chars.ShouldBeOfType<List<Character>>();
        chars.Count.ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object);
        var chara = await _service.GetByIdAsync(1);

        chara.ShouldBeOfType<Character>();
        chara.Id.ShouldBe(1);
        chara.Name.ShouldBe("Test_character_1");
        chara.WeekDays.ShouldBeOfType<string>();
    }
}
