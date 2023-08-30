using System;
namespace Costum_Route_Handler.Handler
{
	public class ImageHandler
	{
		public RequestDelegate Handler(string filePath)
		{
// buradaki async ve c parametrelerinin sebebi RequestDelegate sinifinda Task dondurulur ve httpcontext parametresi ister bu yuzden task donmesi icin async , httpcontext parametresi icin de c parametresi kullaniyoruz
			return async c =>
			{
				// Fileinfo sinifi ilgili dosyayi dizinde bulmamizi ve onun uzerinde islem yapmamizi saglayan bir class dir 
				FileInfo fileInfo = new FileInfo($"{filePath}\\{c.Request.RouteValues["imageName"]}");
				using MagickImage magick = new MagickImage (fileInfo);
				int width = magick.Width, height = magick.Height;
				if (string.IsNullOrEmpty(c.Request.Query["w"].ToString())) ;
				width = int.Parse(c.Request.Query["w"].ToString());
				if (string.IsNullOrEmpty(c.Request.Query["h"].ToString())) ;
				height = int.Parse(c.Request.Query["h"].ToString());
				// yukaridaki islemde boyutlandirmak icin on tanim yapiyoruz , query string kullanarak inte parse ediyoruz
				magick.Resize(width, height); // boyutlandirma islemi
				var buffer = magick.ToByteArray();
				c.Response.Clear();
				c.Response.ContentType = string.Concat("image/", fileInfo.Extension.Replace(".", ""));
				await c.Response.Body.WriteAsync(buffer, 0, buffer.Length);
				await c.Response.WriteAsync(filePath);
			};
		}
	}
}

