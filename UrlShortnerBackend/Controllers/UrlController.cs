using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
	[ApiController]
	[Route("Go")]
	public class UrlController : Controller
	{
		private readonly AppDbContext _context;

		public UrlController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("{code}")]
		public IActionResult Goto(string code)
		{
			var find = _context.UrlShorts.FirstOrDefault(u => u.shortUrl == code);
			if (find == null)
			{
				return NotFound();
			}
			return Redirect(find.longUrl);
		}


		[HttpPost]
		public IActionResult AddUrl(UrlShort url)
		{
			var find2 = _context.UrlShorts.FirstOrDefault(u => u.longUrl == url.longUrl);
			if (find2 != null)
			{
				return Ok(find2);
			}
			var str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890";
			var s = new Random();
			var code ="Goto_";
			for(int i = 0; i <= 8; i++)
			{
				code += str[s.Next(0, 63)];
			}
			url.shortUrl = code;
			var find = _context.UrlShorts.FirstOrDefault(u => u.shortUrl == code);
			if (find != null)
			{
				return BadRequest();
			}
			_context.UrlShorts.Add(url);
			_context.SaveChanges();
			return Ok(url);
		}
	}
}
