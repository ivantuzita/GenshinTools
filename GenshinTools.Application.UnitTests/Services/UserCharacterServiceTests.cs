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

    public UserCharacterServiceTests()
    {
        _mockRepo = MockUserCharacterRepository.GetUserCharacterMockRepository();
        _charMockRepo = MockCharacterRepository.GetCharactersMockRepository();
    }

    [Fact]
    public async Task GetUserCharactersTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object);
        var chars = await _service.GetUserCharacters("lorem_ipsum");

        chars.Count.ShouldBe(2);
        chars.ShouldBeOfType<List<Character>>();
    }

    [Fact]
    public async Task GetUserCharactersFilteredTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object);
        var chars = await _service.GetUserCharactersFiltered("lorem_ipsum");

        //only charId 2 fits
        chars.Count.ShouldBe(1);
        chars.ShouldBeOfType<List<Character>>();
    }


    [Fact]
    public async Task AssociateCharacterToUserTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object);
        await _service.AssociateCharacterToUser("lorem_ipsum", 3);

        var list = await _service.GetUserCharacters("lorem_ipsum");
        var result = list.FirstOrDefault(x => x.Id == 3);

        result.ShouldBeOfType<Character>();
        result.Id.ShouldBe(3);
        result.Name.ShouldBe("test_character_3");
        result.WeekDays.ShouldBeOfType<string>();
    }

    [Fact]
    public async Task DiassociateCharacterToUserTest() {
        var _service = new UserCharacterService(_mockRepo.Object, _charMockRepo.Object);
        await _service.DisassociateCharacterToUser("lorem_ipsum", 2);

        var list = await _service.GetUserCharacters("lorem_ipsum");

        list.Count.ShouldBe(1);
    }
}
