using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;

namespace GenshinTools.Application.UnitTests.Mock;
public class MockCharacterRepository {
    public static Mock<IGenericRepository<Character>> GetCharactersMockRepository() {
        var chars = new List<Character> {
            new Character {
                Id = 1,
                Name = "Test_character_1",
                WeekDays = "2,5",
                Quality = 4
            },
            new Character {
                Id = 2,
                Name = "test_character_2",
                WeekDays = "1,3",
                Quality = 4
            },
            new Character {
                Id = 3,
                Name = "test_character_3",
                WeekDays = "1,3",
                Quality = 4
            }
        };

        var mockRepo = new Mock<IGenericRepository<Character>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(chars);

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var chara = chars.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(chara);
            });

        return mockRepo;
    }
}
