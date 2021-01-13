﻿using AutoMapper;
using MedicineAssistant.Domain.Models;
using System;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Medicines
{
	public class UpdateMedicineDto : IMapFrom<Medicine>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateMedicineDto, Medicine>();
		}
	}
}