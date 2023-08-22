using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MVCProjectEx_.Models.ModelMetaDataTypes;

namespace MVCProjectEx_.Models
{
	[ModelMetadataType(typeof(ProductMetaData))]
	public class Products
	{
		public int Id { get; set; }
	//	[Required(ErrorMessage ="lutfen bir urun adi giriniz")] // DataAnnotations paketini indirerek validasyon islemlerini rahat bir sekilde yapiyoruz, ayni zamanda viewmodel da da bu attributelari kullanabiliriz
	//	[StringLength(100,ErrorMessage ="urun adi 100 karakterden fazla olamaz")]
		public string ProductName { get; set; }
		public int Quentity { get; set; }
	//	[EmailAddress(ErrorMessage ="lutfen gecerli bir email adresi giriniz")]
		public string Email { get; set; }
        public int TotalProduct { get; set; }
		// oncesinde bu model icerisinde validation islemlerini yapiyorduk fakat ModelMetaDataType ozelligi sayesinde ayri bir class olusturarak tum validation islemlerini orada yaptik 
    }
}

