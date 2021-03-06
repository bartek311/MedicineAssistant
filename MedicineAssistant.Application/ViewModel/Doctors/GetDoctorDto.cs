﻿using AutoMapper;
using MedicineAssistant.Domain.Models;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Doctors
{
	public class GetDoctorDto : IMapFrom<Doctor>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public int Id { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<GetDoctorDto, Doctor>();
		}
	}
}