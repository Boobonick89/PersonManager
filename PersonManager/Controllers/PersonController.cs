using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManager.Data;
using PersonManager.Models;
using PersonManager.ViewModels;


namespace PersonManager.Controllers
{
	public class PersonController : Controller
	{
		private readonly AppDbContext _context;

		public PersonController(AppDbContext context)

		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index(string? search, int? ageFrom, int? ageTo)
		{
			PersonViewModel viewModel = new PersonViewModel();

			IQueryable<Person> query = _context.People;



			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(p => EF.Functions.ILike(p.LastName, $"%{search}%")||
									EF.Functions.ILike(p.FirstName,$"%{search}%")||
									EF.Functions.ILike(p.MiddleName,$"%{search}%"));
			}

			if (ageFrom.HasValue)
			{
				query = query.Where(p => p.Age >= ageFrom.Value);
			}

			if (ageTo.HasValue)
			{
				query = query.Where(p => p.Age <= ageTo.Value);
			}

			viewModel.IsSearch =
			!string.IsNullOrWhiteSpace(search)
			|| ageFrom.HasValue
			|| ageTo.HasValue;

			viewModel.People = query.OrderBy(p=>p.LastName)
									.ThenBy(p=>p.FirstName)
									.ThenBy(p=>p.MiddleName)
									.ToList();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			Person? person = _context.People.FirstOrDefault(p => p.Id == id);

			if (person != null)
			{
				_context.People.Remove(person);
				_context.SaveChanges();
			}

			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
		public IActionResult Create(PersonViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.People = _context.People.ToList();
				return View("index", viewModel);

			}

			_context.People.Add(viewModel.NewPerson);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult Edit(Person person)
		{
			if (!ModelState.IsValid)
			{
				return View(person);
			}

			Person? oldPerson = _context.People.FirstOrDefault(p => p.Id == person.Id);

			if (oldPerson != null)

			{
				oldPerson.LastName = person.LastName;
				oldPerson.FirstName = person.FirstName;
				oldPerson.MiddleName = person.MiddleName;

				oldPerson.Age = person.Age;

				_context.SaveChanges();
			}

			return RedirectToAction(nameof(Index));
		}
	}

}