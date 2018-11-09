using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using upbTechSite.Models;
using NLog;
using Microsoft.Extensions.Logging;

namespace upbTechSite.Controllers
{
	public class HomeController : Controller
	{
		protected readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			if (logger != null) _logger = logger;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/index.html"), "text/html");
		}

		[HttpPost]
		[ActionName("sendmessage")]
		public async Task<IActionResult> SendMessage([FromBody] UsersMessageModel usersMessage)
		{
			if (usersMessage == null) return Json("Ошибка при отправке электронного письма");

			try
			{
				SmtpClient client = new SmtpClient(Startup.Configuration.GetSection("SmtpSettings:Host").Value.ToString(),
													25)
				{
					Credentials = new NetworkCredential(Startup.Configuration.GetSection("SmtpSettings:Credentials:Login").Value.ToString(),
														Startup.Configuration.GetSection("SmtpSettings:Credentials:Password").Value.ToString()),
				};

				MailMessage message = EmailMessageFactory.CreateMessage(usersMessage.ToString());

				client.SendCompleted += ((s, e) => 
				{
					message.Dispose();
					client.Dispose();
				});

				await client.SendMailAsync(message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return Json("Ошибка при отправке электронного письма");
			}

			_logger.LogInformation($"Сообщение от {usersMessage.Name} усешно отправлено");
			return Json("Сообщение успешно отправлено");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
