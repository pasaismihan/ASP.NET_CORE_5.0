using System;
using FluentValidation;

namespace MVCProjectEx_.Models.Validators
{
	public class ProductValidator : AbstractValidator<Products> // Bir classi validator yapmak icin abstractvalidatordan kalitim almasi lazim , sonrasinda generik olarak calisacagimiz class i yazdik (Products)
	{

		public ProductValidator()
		{
			RuleFor(x => x.Email).NotNull().WithMessage("lutfen email alanini bos gecmeyiniz");
			RuleFor(x => x.Email).EmailAddress().WithMessage("gecerli email adresi girmek zorundasiniz");
			RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("bir urun adi girmek zorundasiniz");
			RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("lutfen 100 karakterden fazla girmeyiniz");
		}
	}
}

