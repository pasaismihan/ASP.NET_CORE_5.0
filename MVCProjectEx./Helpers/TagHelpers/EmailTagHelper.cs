using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCProjectEx_.Helpers.TagHelpers
{
    // Mvc taghelper kullanmak icin taghelper class indan kalitim almasi gerekir...
    [HtmlTargetElement("costumEmail")] // EmailTagHelperdaki email disinda bir tag ile emaili olusturmak istersek (yazdigimiz costumemail gibi ) bu sekilde htmltargetelement diyoruz
	public class EmailTagHelper : TagHelper
	{
        public string Mail { get; set; }
        public string Display { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{Mail}");
            output.Content.Append(Display);
            //base.Process(context, output);
            // bu bolumde override ettigimizde karsimiza cikan Process metodu email tagimizin ozelliklerini temsil etmektedir , aldigi context parametresi ilgili email taginin attribute ozellikleri, output da verdigi cikti ozelliklerini temsil eder 
        }
    }

}

 