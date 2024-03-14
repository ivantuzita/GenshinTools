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
public class CharacterServiceTests {

    private readonly Mock<IGenericRepository<Character>> _mockRepo;
    private IMapper _mapper;

    public CharacterServiceTests()
    {
        _mockRepo = MockCharacterRepository.GetCharactersMockRepository();
        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<CharacterProfile>(); });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAllAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object, _mapper);
        var chars = await _service.GetAllAsync();

        chars.ShouldBeOfType<List<Character>>();
        chars.Count.ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object, _mapper);
        var chara = await _service.GetByIdAsync(1);

        chara.ShouldBeOfType<Character>();
        chara.Id.ShouldBe(1);
        chara.Name.ShouldBe("Test_character_1");
        chara.WeekDays.ShouldBeOfType<List<int>>();
    }

    [Fact]
    public async Task DeleteByIdTest() {
        var _service = new CharacterService(_mockRepo.Object, _mapper);

        var getAll = await _service.GetAllAsync();

        await _service.DeleteByIdAsync(3);

        getAll.Count.ShouldBe(2);
    }

    [Fact]
    public async Task CreateAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object, _mapper);
        var charDTO = new CharacterDTO {
            Name = "Test_character_4",
            WeekDays = "0,2"
        };

        await _service.CreateAsync(charDTO);

        var chars = await _service.GetAllAsync();

        chars.ShouldBeOfType<List<Character>>();
        chars.Count.ShouldBe(4);
    }

    [Fact]
    public async Task UpdateAsyncTest() {
        var _service = new CharacterService(_mockRepo.Object, _mapper);
        var chara = new CharacterDTO { Id = 1, Name = "Test_character_replacement" };

        await _service.UpdateAsync(chara);

        var updated = await _service.GetByIdAsync(1);

        updated.ShouldBeOfType<Character>();
        updated.Id.ShouldBe(1);
        updated.Name.ShouldBe("Test_character_replacement");
        updated.WeekDays.ShouldBeOfType<List<int>>();
    }
}
