using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upbTechSite.Models
{
	public class UsersMessage
	{
		public string Name { get; set; }

		public string Company { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Message { get; set; }

		public UsersMessage()
		{ }

		public UsersMessage(string name, string company, string email, string phone, string message)
		{
			Name = name;
			Company = company;
			Email = email;
			Phone = phone;
			Message = message;
		}

		public override string ToString()
		{
			return $"Имя пользователя: {Name}" + Environment.NewLine +
				   $"Название компании: {Company}" + Environment.NewLine +
				   $"Электронная поча: {Email}" + Environment.NewLine +
				   $"Мобильный телефон: {Phone}" + Environment.NewLine + Environment.NewLine + 
				   $"Сообщение от клиента:" + Environment.NewLine + Message;
		}
	}
}
