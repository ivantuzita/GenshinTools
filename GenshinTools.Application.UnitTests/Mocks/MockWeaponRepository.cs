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
                WeekDays = "2,5"
            },
            new Weapon {
                Id = 2,
                Name = "test_weapon_2",
                WeekDays = "1,3"
            },
            new Weapon {
                Id = 3,
                Name = "test_weapon_3",
                WeekDays = "1,3"
            }
        };

        var mockRepo = new Mock<IGenericRepository<Weapon>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(weapons);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Weapon>()))
            .Returns((Weapon weapon) => {
                weapons.Add(weapon);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var weapon = weapons.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(weapon);
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Weapon>()))
            .Returns((Weapon weapon) => {
                //find object
                var obj = weapons.FirstOrDefault(u => u.Id == weapon.Id);
                //updating object...
                if (obj != null)
                {
                    obj.Id = weapon.Id;
                    obj.Name = weapon.Name;
                    obj.WeekDays = weapon.WeekDays;
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.DeleteByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = weapons.Find(u => u.Id == id);

                if (obj != null)
                {
                    weapons.Remove(obj);
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        return mockRepo;
    }
}
