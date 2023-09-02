using System;
using AutoMapper;
using DTO_Yapilari_ViewModel.Models;
using DTO_Yapilari_ViewModel.Models.ViewModels;

namespace DTO_Yapilari_ViewModel.AutoMappers
{
	public class PersonelProfil : Profile //Profile kalitimi automappera ait bir ozelliktir, burada bir profil olusturuyoruz Personele ait  
	{
		public PersonelProfil()
		{
			CreateMap<Personel, PersonelCreateVM>();
			CreateMap<PersonelCreateVM, Personel>();
		}
	}
}

