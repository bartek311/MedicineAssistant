﻿using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Users;
using MedicineAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Interfaces
{
	public interface IUserService
	{
		Task<string> CreateNormalUserAsync(CreateUserDto dto);
		Task<string> CreateAdminUserAsync(CreateUserDto dto);
		Task<List<GetUserDto>> GetAllUsersAsync();
		Task<GetUserDto> GetUserByIdAsync(string id);
		Task<GetUserDto> GetUserByEmailAsync(string email);
		Task EditUserAsync(UpdateUserDto dto);
		Task DeleteUserAsync(string id);
		Task<bool> CheckPasswordAsync(AccountDto user, string password);
	}
}