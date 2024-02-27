using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Application.MappingProfiles;
using GenshinTools.Application.Services;
using GenshinTools.Application.UnitTests.Mock;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using Moq;
using Shouldly;

namespace GenshinTools.Application.UnitTests.Services;

public class UserServiceTests {
    private readonly Mock<IGenericRepository<User>> _mockRepo;
    private IMapper _mapper;
    public UserServiceTests()
    {
        _mockRepo = MockUserRepository.GetUserMockRepository();
        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<UserProfile>(); });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAllAsyncTest()
    {
        var _service = new UserService(_mockRepo.Object, _mapper);
        var users = await _service.GetAllAsync();

        users.ShouldBeOfType<List<User>>();
        users.Count.ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdAsyncTest()
    {
        var _service = new UserService(_mockRepo.Object, _mapper);
        var user = await _service.GetByIdAsync(1);

        user.ShouldBeOfType<User>();
        user.Id.ShouldBe(1);
        user.Username.ShouldBe("Test_User_1");
        user.Password.ShouldBe("Valid.Password1!");
    }

    [Fact]
    public async Task DeleteByIdTest()
    {
        var _service = new UserService(_mockRepo.Object, _mapper);

        var getAll = await _service.GetAllAsync();

        await _service.DeleteByIdAsync(3);

        getAll.Count.ShouldBe(2);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var _service = new UserService(_mockRepo.Object, _mapper);
        var userDTO = new UserDTO
        {
            Username = "Test_User_4",
            Password = "Valid.Password1!"
        };

        await _service.CreateAsync(userDTO);

        var users = await _service.GetAllAsync();

        users.ShouldBeOfType<List<User>>();
        users.Count.ShouldBe(4);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var _service = new UserService(_mockRepo.Object, _mapper);
        var user = new UserDTO { Id = 1, Username = "Test_User_replacement", Password = "Valid.Password2!" };

        await _service.UpdateAsync(user);

        var updated = await _service.GetByIdAsync(1);

        updated.ShouldBeOfType<User>();
        updated.Id.ShouldBe(1);
        updated.Username.ShouldBe("Test_User_replacement");
        updated.Password.ShouldBe("Valid.Password2!");
    }
}
