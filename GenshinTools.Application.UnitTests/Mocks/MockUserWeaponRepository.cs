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
                Password = "password1"
            },
            new User {
                Id = 2,
                Username = "test_User_2",
                Password = "password2"
            },
            new User {
                Id = 3,
                Username = "test_User_3",
                Password = "password3"
            }
        };

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
                var result = chars.Where(x => userWeaponsList.Contains(x.Id)).ToList();
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.GetUserWeaponsFiltered(It.IsAny<int>()))
            .Returns((int id) => {
                var userWeaponsList = userWeapons.Where(q => q.UserId == id)
                .Select(x => x.WeaponId)
                .ToList();
                var result = chars.Where(x => userWeaponsList.Contains(x.Id)).ToList();

                var filter = result.Where(y => y.WeekDays.Contains(3)).ToList();
                return Task.FromResult(result);
            });

        return mockRepo;
    }
}
