using AutoMapper;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;
using System;

namespace GenshinTools.BlazorUI.Services {
    public class UserService : BaseHttpService, IUserService {

        private readonly IMapper _mapper;

        public UserService(IClient client, IMapper mapper) : base(client) {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateUserAsync(UserVM user) {
            try {
                var newUser = _mapper.Map<UserDTO>(user);
                await _client.UsersPOSTAsync(newUser);
                return new Response<Guid> {
                    Success = true,
                };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteUserByIdAsync(int id) {
            try {
                await _client.UsersDELETEAsync(id);
                return new Response<Guid> { Success = true, };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<UserVM>> GetAllUsersAsync() {
            var users = await _client.UsersAllAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<UserVM> GetUserByIdAsync(int id) {
            var user = await _client.UsersGETAsync(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<Response<Guid>> UpdateUserAsync(int id, UserVM user) {
            try {
                var newUser = _mapper.Map<UserDTO>(user);
                await _client.UsersPUTAsync(id.ToString(), newUser);
                return new Response<Guid> {
                    Success = true,
                };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
