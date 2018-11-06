using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace upbTechSite.Models
{
	public static class EmailMessageFactory
	{
		// TODO: create from, to, message subject and body from configuration file

		public static MailMessage CreateMessage(string messageBody)
		{
			MailAddress from = new MailAddress(Startup.Configuration.GetSection("SmtpSettings:Email").Value.ToString(),
												Startup.Configuration.GetSection("SmtpSettings:DisplayName").Value.ToString(),
												System.Text.Encoding.UTF8);

			MailAddress to = new MailAddress(Startup.Configuration.GetSection("SmtpSettings:MainRecepient").Value.ToString());

			MailMessage message = new MailMessage(from, to)
			{
				Subject = Startup.Configuration.GetSection("SmtpSettings:MessageSubject").Value.ToString(),
				Body = messageBody,
				BodyEncoding = System.Text.Encoding.UTF8
			};

			return message;
		}
	}
}
