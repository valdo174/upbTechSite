using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upbTechSite.Models
{
	public class UsersMessageModel
	{
		public string Name { get; set; }

		public string Company { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Message { get; set; }

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
