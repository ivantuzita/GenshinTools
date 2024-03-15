using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models.Identity;
using Moq;

namespace GenshinTools.Application.UnitTests.Mock;

public class MockUserRepository
{
    public static Mock<IGenericRepository<AuthRequest>> GetUserMockRepository()
    {
        var users = new List<AuthRequest> {
            new AuthRequest {
                Id = 1,
                Username = "Test_User_1",
                Password = "Valid.Password1!"
            },
            new AuthRequest {
                Id = 2,
                Username = "test_User_2",
                Password = "Valid.Password1!"
            },
            new AuthRequest {
                Id = 3,
                Username = "test_User_3",
                Password = "Valid.Password1!"
            }
        };

        var mockRepo = new Mock<IGenericRepository<AuthRequest>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<AuthRequest>()))
            .Returns((AuthRequest user) => {
                users.Add(user);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var user = users.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(user);
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<AuthRequest>()))
            .Returns((AuthRequest user) => {
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
