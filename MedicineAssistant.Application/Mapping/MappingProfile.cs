﻿using AutoMapper;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Doctors;
using MedicineAssistant.Application.ViewModel.Medicines;
using MedicineAssistant.Application.ViewModel.UserMedicines;
using MedicineAssistant.Application.ViewModel.Users;
using MedicineAssistant.Domain.Models;

namespace MedicineAssistant.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateDoctorDto, Doctor>();
			CreateMap<Doctor, GetDoctorDto>();
			CreateMap<UpdateDoctorDto, Doctor>();

			CreateMap<CreateMedicineDto, Medicine>();
			CreateMap<Medicine, GetMedicineDto>();
			CreateMap<UpdateMedicineDto, Medicine>();

			CreateMap<UserMedicine, AddMedicineToUserDto>().ReverseMap();
			CreateMap<UserMedicine, GetMedicineDto>().ReverseMap();
			CreateMap<UserMedicine, UpdateUserMedicinesDto>().ReverseMap();
			CreateMap<UserMedicine, GetUserMedicinesDto>().ReverseMap();

			CreateMap<CreateUserDto, ApplicationUser>();
			CreateMap<ApplicationUser, GetUserDto>();
			CreateMap<UpdateUserDto, ApplicationUser>();
			CreateMap<AccountDto, ApplicationUser>();
		}
	}
}