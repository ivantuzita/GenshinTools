using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;

namespace GenshinTools.Application.UnitTests.Mock;

public class MockUserRepository
{
    public static Mock<IGenericRepository<User>> GetUserMockRepository()
    {
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

        var mockRepo = new Mock<IGenericRepository<User>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<User>()))
            .Returns((User user) => {
                users.Add(user);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var user = users.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(user);
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>()))
            .Returns((User user) => {
                //find object
                var obj = users.FirstOrDefault(u => u.Id == user.Id);
                //updating object...
                if (obj != null)
                {
                    obj.Id = user.Id;
                    obj.Username = user.Username;
                    obj.Password = user.Password;
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.DeleteByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = users.FirstOrDefault(u => u.Id == id);

                if (obj != null)
                {
                    users.Remove(obj);
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        return mockRepo;
    }
}
