﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Users;
using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(IUserRepository userRepo, IMapper mapper, UserManager<ApplicationUser> userManager)
		{
			_userRepo = userRepo;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<bool> CheckPasswordAsync(AccountDto user, string password)
		{
			return await _userRepo.CheckPasswordAsync(_mapper.Map<ApplicationUser>(user), password);
		}

		public async Task<string> CreateNormalUserAsync(CreateUserDto dto)
		{
			return await _userRepo.CreateNormalUserAsync(_mapper.Map<ApplicationUser>(dto), dto.Password);
		}

		public async Task<string> CreateAdminUserAsync(CreateUserDto dto)
		{
			return await _userRepo.CreateAdminUserAsync(_mapper.Map<ApplicationUser>(dto), dto.Password);
		}

		public async Task DeleteUserAsync(string id)
		{
			await _userRepo.DeleteUserAsync(id);
		}

		public async Task EditUserAsync(UpdateUserDto dto)
		{
			var user = await _userRepo.GetUserByIdAsync(dto.Id);
			user.Email = dto.Email;
			user.UserName = dto.Email;
			user.NormalizedUserName = dto.Email;
			user.NormalizedEmail = dto.Email;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);
			await _userRepo.EditUserAsync(_mapper.Map<ApplicationUser>(user));
		}

		public async Task<List<GetUserDto>> GetAllUsersAsync()
		{
			var item = await _userRepo.GetAllUsers()
				   .ProjectTo<GetUserDto>(_mapper.ConfigurationProvider)
				   .ToListAsync();
			return item;
		}

		public async Task<GetUserDto> GetUserByEmailAsync(string email)
		{
			var item = await _userRepo.GetUserByEmailAsync(email);
			return _mapper.Map<GetUserDto>(item);
		}

		public async Task<GetUserDto> GetUserByIdAsync(string id)
		{
			var item = await _userRepo.GetUserByIdAsync(id);
			return _mapper.Map<GetUserDto>(item);
		}
	}
}