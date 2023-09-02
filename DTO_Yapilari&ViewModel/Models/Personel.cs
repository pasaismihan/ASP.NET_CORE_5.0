using System;
using DTO_Yapilari_ViewModel.Models.ViewModels;

namespace DTO_Yapilari_ViewModel.Models
{
	public class Personel
	{
		public int Id { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string Pozisyon { get; set; }
		public int Maas { get; set; }
		public bool MedeniHal { get; set; }

        #region Implicit Donusum/ Gizli/ Bilincsiz
        public static implicit operator PersonelCreateVM(Personel model)
        {
            return new PersonelCreateVM
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi
            };
        }
        public static implicit operator Personel(PersonelCreateVM model)
        {
            return new Personel
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi
            };
        }
        #endregion

    }


}

