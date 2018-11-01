using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using upbTechSite.Models;

namespace upbTechSite.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/index.html"), "text/html");
		}

		[HttpPost]
		[ActionName("sendmessage")]
		public IActionResult SendMessage()
		{
			try
			{
				SmtpClient client = new SmtpClient("smtp.test", 25)
				{
					Credentials = new NetworkCredential("login", "pass"),
				};

				MailAddress from = new MailAddress("info@upb-tech.ru", "УРАЛПРОМТЕХ. Форма обратной связи upb-tech.ru");
				MailAddress to = new MailAddress("recepient@test.com");

				MailMessage message = new MailMessage(from, to)
				{
					Subject = "Сообщение от посетителя upb-tech.ru",
					Body = "Тестовое сообщение от домена upb-tech.ru",
					BodyEncoding = System.Text.Encoding.UTF8
				};

				client.Send(message);

				message.Dispose();
				client.Dispose();
			}
			catch (Exception)
			{
				return Json("Ошибка при отправке электронного письма");
			}

			return Json("Сообщение успешно доставлено");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
