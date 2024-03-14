using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace GenshinTools.Application.UnitTests.Mocks;
public class MockUserCharacterRepository
{
    public static Mock<IUserCharacterRepository> GetUserCharacterMockRepository()
    {
        var userChars = new List<UserCharacter> {
            new UserCharacter {
                UserId = 1,
                CharacterId = 1
            },
            new UserCharacter {
                UserId = 1,
                CharacterId = 2
            },
            new UserCharacter {
                UserId = 2,
                CharacterId = 1
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

        var chars = new List<Character> {
            new Character {
                Id = 1,
                Name = "Test_character_1",
                WeekDays = "2,5"
            },
            new Character {
                Id = 2,
                Name = "test_character_2",
                WeekDays = "1,3"
            },
            new Character {
                Id = 3,
                Name = "test_character_3",
                WeekDays = "1,3"
            }
        };

        var mockRepo = new Mock<IUserCharacterRepository>();

        mockRepo.Setup(r => r.AlreadyAssociated(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int userid, int charid) => {
                var result = userChars.Any(x => x.UserId == userid && x.CharacterId == charid);
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.AssociateCharacterToUser(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int userid, int characterid) => {
                var userChar = new UserCharacter {UserId = userid, CharacterId = characterid};
                userChars.Add(userChar);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.DisassociateCharacterToUser(It.IsAny<int>(), It.IsAny<int>()))
        .Returns((int userid, int characterid) => {
                var obj = userChars.Where(q => q.UserId == userid
                    && q.CharacterId == characterid).FirstOrDefault();
                userChars.Remove(obj);
                return Task.CompletedTask;
        });

        mockRepo.Setup(r => r.GetUserCharacters(It.IsAny<int>()))
            .Returns((int id) => {
                var userCharsList = userChars.Where(q => q.UserId == id)
                    .Select(x => x.CharacterId)
                    .ToList();

                // not sure if this is correct or the most efficient way to do this.
                var result = chars.Where(x => userCharsList.Contains(x.Id)).ToList();
                return Task.FromResult(result);
        });

        mockRepo.Setup(r => r.GetUserCharactersFiltered(It.IsAny<int>()))
            .Returns((int id) => {
                var userCharsList = userChars.Where(q => q.UserId == id)
                .Select(x => x.CharacterId)
                .ToList();
                var result = chars.Where(x => userCharsList.Contains(x.Id)).ToList();

                var filter = result.Where(y => y.WeekDays.Contains("3")).ToList();
                return Task.FromResult(filter);
            });

        return mockRepo;
    }
}
