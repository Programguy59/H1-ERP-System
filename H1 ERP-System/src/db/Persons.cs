using H1_ERP_System.customer;

namespace H1_ERP_System.db;

public static partial class Database
{
	public static readonly List<Person> Persons = new();

	public static Person? GetPersonById(int id)
	{
		return Persons.FirstOrDefault(person => person.PersonId == id);
	}

	public static List<Person> GetAllPersons()
	{
		return Persons;
	}
}
