using System;
namespace MVCProjectEx_.Models.ViewModels
{
	public class EmployeeProduct
	{
	    public Products? Products { get; set; }
		public Employee? Employee { get; set; }
		//ViewModel da ayri bir yapilanmadir birden fazla modeli birlestirerek bunu tek bir actiona gondermemize olanak saglar 
	}
}

