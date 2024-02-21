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
                WeekDays = new List<int> {2, 5}
            },
            new Character {
                Id = 2,
                Name = "test_character_2",
                WeekDays = new List<int> {1, 3}
            },
            new Character {
                Id = 3,
                Name = "test_character_3",
                WeekDays = new List<int> {1, 3}
            }
        };

        var mockRepo = new Mock<IGenericRepository<Character>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(chars);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Character>()))
            .Returns((Character chara) => {
                chars.Add(chara);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var chara = chars.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(chara);
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Character>()))
            .Returns((Character chara) => {
                //find object
                var obj = chars.FirstOrDefault(u => u.Id == chara.Id);
                //updating object...
                if (obj != null) {
                    obj.Id = chara.Id;
                    obj.Name = chara.Name;
                    obj.WeekDays = chara.WeekDays;
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.DeleteByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = chars.Find(u => u.Id == id);

                if (obj != null) {
                    chars.Remove(obj);
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        return mockRepo;
    }
}
