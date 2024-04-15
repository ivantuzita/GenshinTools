using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;

namespace GenshinTools.Application.UnitTests.Mock;

public class MockWeaponRepository
{
    public static Mock<IGenericRepository<Weapon>> GetWeaponsMockRepository()
    {
        var weapons = new List<Weapon> {
            new Weapon {
                Id = 1,
                Name = "Test_weapon_1",
                WeekDays = "2,5",
                Quality = 4
            },
            new Weapon {
                Id = 2,
                Name = "test_weapon_2",
                WeekDays = "1,3",
                Quality = 4
            },
            new Weapon {
                Id = 3,
                Name = "test_weapon_3",
                WeekDays = "1,3",
                Quality = 4
            }
        };

        var mockRepo = new Mock<IGenericRepository<Weapon>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(weapons);

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var weapon = weapons.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(weapon);
            });

        return mockRepo;
    }
}
