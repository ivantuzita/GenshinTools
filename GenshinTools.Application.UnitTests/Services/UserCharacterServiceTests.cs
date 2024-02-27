using AutoMapper;
using GenshinTools.Application.MappingProfiles;
using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Application.UnitTests.Mocks;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services;
public class UserCharacterServiceTests {

    private readonly Mock<IUserCharacterRepository> _mockRepo;
    private readonly Mock<IGenericRepository<Character>> _charMockRepo;
    private readonly Mock<IGenericRepository<User>> _userMockRepo;

    public UserCharacterServiceTests()
    {
        _mockRepo = MockUserCharacterRepository.GetUserCharacterMockRepository();
        _charMockRepo = MockCharacterRepository.GetCharactersMockRepository();
        _userMockRepo = MockUserRepository.GetUserMockRepository();
    }

    [Fact]
    public async Task GetUserCharactersTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object, _userMockRepo.Object);
        var chars = await _service.GetUserCharacters(1);

        chars.Count.ShouldBe(2);
        chars.ShouldBeOfType<List<Character>>();
    }

    [Fact]
    public async Task GetUserCharactersFilteredTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object, _userMockRepo.Object);
        var chars = await _service.GetUserCharactersFiltered(1);

        //only charId 2 fits
        chars.Count.ShouldBe(1);
        chars.ShouldBeOfType<List<Character>>();
    }


    [Fact]
    public async Task AssociateCharacterToUserTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object, _userMockRepo.Object);
        await _service.AssociateCharacterToUser(1, 3);

        var list = await _service.GetUserCharacters(1);
        var result = list.FirstOrDefault(x => x.Id == 3);

        result.ShouldBeOfType<Character>();
        result.Id.ShouldBe(3);
        result.Name.ShouldBe("test_character_3");
        result.WeekDays.ShouldBeOfType<List<int>>();
    }

    [Fact]
    public async Task DiassociateCharacterToUserTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object, _userMockRepo.Object);
        await _service.DisassociateCharacterToUser(1, 2);

        var list = await _service.GetUserCharacters(1);

        list.Count.ShouldBe(1);
    }
}
