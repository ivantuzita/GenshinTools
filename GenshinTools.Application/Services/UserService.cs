﻿using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services;
public class UserService : IUserService {

    private readonly IGenericRepository<User> _repository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(UserDTO userDTO) {
        var newUser = _mapper.Map<User>(userDTO);
        await _repository.CreateAsync(newUser);
    }

    public async Task DeleteByIdAsync(int id) {
        await _repository.DeleteByIdAsync(id);
    }

    //don't know if returning User is correct... shouldn't it be 'UserDTO'?
    public async Task<List<User>> GetAllAsync() {
        var result = await _repository.GetAllAsync();

        if (result == null) {
            throw new Exception("No users found.");
        }

        return result;
    }

    public async Task<UserDTO> GetByIdAsync(int id) {
        var result = await GetByIdAsync(id);
        return result;
    }

    public async Task UpdateAsync(UserDTO userDTO) {
        var existingUser = await _repository.GetByIdAsync(userDTO.Id);

        if (existingUser == null) {
            throw new NotFoundException($"User with id {userDTO.Id} has not been found.");
        }

        var newUser = _mapper.Map<User>(userDTO);
        await _repository.UpdateAsync(newUser);
    }
}
