using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO_Yapilari_ViewModel.Business;
using DTO_Yapilari_ViewModel.Models;
using DTO_Yapilari_ViewModel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DTO_Yapilari_ViewModel.Controllers
{
    public class PersonelController : Controller
    {
       public IMapper Mapper { get; }
        public PersonelController(IMapper mapper){
            Mapper = mapper;
        }
        [HttpPost]
        public IActionResult Index(PersonelCreateVM personelCreateVM)
        {
            #region Implicit Donusturme 
            Personel personel = personelCreateVM;
            // veya
            PersonelCreateVM vM = personel;
            #endregion
            #region Explicit Donusturme 
            Personel p = (Personel)personelCreateVM; // explicit de cast etmemiz gerekiyor ve model bolumunde implicit yazdigimiz yeri explicit diye degistirecegiz
            PersonelCreateVM p2 = (PersonelCreateVM)p;
            #endregion
            #region Reflection Ile Donusturme
            Personel pp = TypeConversion.Conversion<PersonelCreateVM, Personel>(personelCreateVM);
            #endregion
            #region AutoMapper 
            Personel ppp =   Mapper.Map<Personel>(personelCreateVM);
            PersonelCreateVM pp2 = Mapper.Map<PersonelCreateVM>(ppp);

            #endregion

            return View();
        }
        public IActionResult Listele()
        {
            List<PersonelListeVM> personeller = new List<Personel>
            {
                new Personel {Adi="A", Soyadi="B"},
                new Personel {Adi="A1", Soyadi="B"},
                new Personel {Adi="A2", Soyadi="B"},
                new Personel {Adi="A3", Soyadi="B"},
                new Personel {Adi="A4", Soyadi="B"},
                new Personel {Adi="A5", Soyadi="B"},

            }.Select(p => new PersonelListeVM
            {
                Adi = p.Adi,
                Soyadi = p.Soyadi,
                Pozisyon = p.Pozisyon
            }).ToList();
            return View(personeller);
        }
    }
}

