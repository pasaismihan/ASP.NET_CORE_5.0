using System;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectEx_.Models.ModelMetaDataTypes
{
	public class ProductMetaData
	{
        // product classina ait tum validasyon islemlerini yapmak icin bu sinifi olusturduk , viewda yapmak istememizin sebebi solid prensibi olan single responsibilites kavramina ters hareket etmemiz

        [Required(ErrorMessage ="lutfen bir urun adi giriniz")] 
        [StringLength(100,ErrorMessage ="urun adi 100 karakterden fazla olamaz")]
        public string ProductName { get; set; }
      
        [EmailAddress(ErrorMessage = "lutfen gecerli bir email adresi giriniz")]
        public string Email { get; set; }
       
    }
}

