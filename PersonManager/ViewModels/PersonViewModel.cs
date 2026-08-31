using PersonManager.Models;


namespace PersonManager.ViewModels
{
	public class PersonViewModel
	{
		public Person NewPerson { get; set; } = new();
		public List<Person> People { get; set; } = new();

		public bool IsSearch{  get; set; }
	}
}
