using H1_ERP_System.customer;

namespace H1_ERP_System.db;

public partial class Database
{
	public static List<Person> Persons = new();
	
	public static Person? GetPersonById(int id)
	{
		return Persons.FirstOrDefault(person => person.Id == id);
	}

	public static List<Person> GetAllPersons()
	{
		return Persons;
	}

	public static void InsertPerson(Person person)
	{
		Persons.Add(person);
	}

	public static bool UpdatePerson(Person person, int id)
	{
		var existingPerson = GetPersonById(id);
		if (existingPerson == null)
		{
			return false;
		}

		existingPerson.Id = person.Id;
		
		existingPerson.FirstName = person.FirstName;
		existingPerson.LastName = person.LastName;
		existingPerson.FullName = person.FirstName + " " + person.LastName;

		existingPerson.Email = person.Email;
		existingPerson.PhoneNumber = person.PhoneNumber;

		existingPerson.Address = person.Address;

		return true;
	}

	public static bool DeletePersonById(int id)
	{
		var personToDelete = GetPersonById(id);

		if (personToDelete == null)
		{
			return false;
		}

		Persons.Remove(personToDelete);

		return true;
	}

	public static void ClearPersons()
	{
		Persons.Clear();
	}
}
