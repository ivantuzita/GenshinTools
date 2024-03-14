using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;

namespace GenshinTools.Application.UnitTests.Mocks;

public class MockUserWeaponRepository
{
    public static Mock<IUserWeaponRepository> GetUserWeaponMockRepository()
    {
        var userWeapons = new List<UserWeapon> {
            new UserWeapon {
                UserId = 1,
                WeaponId = 1
            },
            new UserWeapon {
                UserId = 1,
                WeaponId = 2
            },
            new UserWeapon {
                UserId = 2,
                WeaponId = 1
            }
        };

        var users = new List<User> {
            new User {
                Id = 1,
                Username = "Test_User_1",
                Password = "Valid.Password1!"
            },
            new User {
                Id = 2,
                Username = "test_User_2",
                Password = "Valid.Password1!"
            },
            new User {
                Id = 3,
                Username = "test_User_3",
                Password = "Valid.Password1!"
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

        mockRepo.Setup(r => r.AlreadyAssociated(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int userId, int weaponId) => {
                var result = userWeapons.Any(x => x.UserId == userId && x.WeaponId == weaponId);
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.AssociateWeaponToUser(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int userId, int weaponId) => {
                var userWeapon = new UserWeapon { UserId = userId, WeaponId = weaponId };
                userWeapons.Add(userWeapon);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.DisassociateWeaponToUser(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int userId, int weaponId) => {
                var obj = userWeapons.Where(q => q.UserId == userId
                    && q.WeaponId == weaponId).FirstOrDefault();
                userWeapons.Remove(obj);
                return Task.CompletedTask;
        });

        mockRepo.Setup(r => r.GetUserWeapons(It.IsAny<int>()))
            .Returns((int id) => {
                var userWeaponsList = userWeapons.Where(q => q.UserId == id)
                    .Select(x => x.WeaponId)
                    .ToList();

                // not sure if this is correct or the most efficient way to do this.
                var result = weapons.Where(x => userWeaponsList.Contains(x.Id)).ToList();
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.GetUserWeaponsFiltered(It.IsAny<int>()))
            .Returns((int id) => {
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
