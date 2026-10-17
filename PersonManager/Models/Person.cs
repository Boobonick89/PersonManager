using System.ComponentModel.DataAnnotations;

namespace PersonManager.Models
{
	public class Person
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите Фамилию")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите Имя")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите Отчество")]
		public string MiddleName { get; set; } = string.Empty;

		[Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120")]
		public int Age { get; set; }

	}
}
