using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;
using Moq;

namespace GenshinTools.Application.UnitTests.Mocks;

public class MockUserWeaponRepository
{
    public static Mock<IUserWeaponRepository> GetUserWeaponMockRepository()
    {
        var userWeapons = new List<UserWeapon> {
            new UserWeapon {
                UserId = "lorem_ipsum",
                WeaponId = 1
            },
            new UserWeapon {
                UserId = "lorem_ipsum",
                WeaponId = 2
            },
            new UserWeapon {
                UserId = "amet_consectur",
                WeaponId = 1
            }
        };

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

        var mockRepo = new Mock<IUserWeaponRepository>();

        mockRepo.Setup(r => r.AlreadyAssociated(It.IsAny<string>(), It.IsAny<int>()))
            .Returns((string userId, int weaponId) => {
                var result = userWeapons.Any(x => x.UserId == userId && x.WeaponId == weaponId);
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.AssociateWeaponToUser(It.IsAny<string>(), It.IsAny<int>()))
            .Returns((string userId, int weaponId) => {
                var userWeapon = new UserWeapon { UserId = userId, WeaponId = weaponId };
                userWeapons.Add(userWeapon);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.DisassociateWeaponToUser(It.IsAny<string>(), It.IsAny<int>()))
            .Returns((string userId, int weaponId) => {
                var obj = userWeapons.Where(q => q.UserId == userId
                    && q.WeaponId == weaponId).FirstOrDefault();
                userWeapons.Remove(obj);
                return Task.CompletedTask;
        });

        mockRepo.Setup(r => r.GetUserWeapons(It.IsAny<string>()))
            .Returns((string id) => {
                var userWeaponsList = userWeapons.Where(q => q.UserId == id)
                    .Select(x => x.WeaponId)
                    .ToList();

                // not sure if this is correct or the most efficient way to do this.
                var result = weapons.Where(x => userWeaponsList.Contains(x.Id)).ToList();
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.GetUserWeaponsFiltered(It.IsAny<string>()))
            .Returns((string id) => {
                var userWeaponsList = userWeapons.Where(q => q.UserId == id)
                .Select(x => x.WeaponId)
                .ToList();
                var result = weapons.Where(x => userWeaponsList.Contains(x.Id)).ToList();

                var filter = result.Where(y => y.WeekDays.Contains("3")).ToList();
                return Task.FromResult(filter);
            });

        return mockRepo;
    }
}
