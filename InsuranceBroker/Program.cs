using InsuranceBroker;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //ArrayExample();
        //ListExample();
        //IEnumerableExample();
        //DeferredExecutionExample();
        //HashSetExample();
        //DictionaryExample();
        //InsurancePolicyExample();
        //InsuranceDataAccessInsertExample();
        //InsuranceDataAccessUpdateExample();
        //InsuranceDataAccessDeleteExample();
        //InsuranceDataAccessExample();
        InsuranceDataAccessGetPoliciesExample();
    }
    static void InsuranceDataAccessGetPoliciesExample()
    {
        string connectionString = "Data Source = localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog = InsuranceBrokerDatabase; TrustServerCertificate=True";
        InsuranceDataAccess dataAccess = new InsuranceDataAccess(connectionString);
        dataAccess.GetInsurancePolicies();
    }

    static void InsuranceDataAccessDeleteExample()
    {
        string connectionString = "Data Source = localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog = InsuranceBrokerDatabase; TrustServerCertificate=True";
        InsuranceDataAccess dataAccess = new InsuranceDataAccess(connectionString);

        int personIdToDelete = 5; // Example person ID
        int vehicleIdToDelete = 5; // Example vehicle ID

        dataAccess.DeletePerson(personIdToDelete);
        dataAccess.DeleteVehicle(vehicleIdToDelete);
    }

    static void InsuranceDataAccessUpdateExample()
    {
        string connectionString = "Data Source = localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog = InsuranceBrokerDatabase; TrustServerCertificate=True";
        InsuranceDataAccess dataAccess = new InsuranceDataAccess(connectionString);

        int personIdToUpdate = 5; // Example person ID
        Person updatedPerson = new Person { FirstName = "Lionel", LastName = "Thornhill" };

        int vehicleIdToUpdate = 5; // Example vehicle ID
        Vehicle updatedVehicle = new Vehicle { Make = "Peugeot", Model = "308" };

        dataAccess.EditPerson(personIdToUpdate, updatedPerson);
        dataAccess.EditVehicle(vehicleIdToUpdate, updatedVehicle);
    }

    static void InsuranceDataAccessInsertExample()
    {
        string connectionString = "Data Source = localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog = InsuranceBrokerDatabase; TrustServerCertificate=True";
        InsuranceDataAccess dataAccess = new InsuranceDataAccess(connectionString);

        Person newPerson = new Person { FirstName = "Lionel", LastName = "Fusco" };
        Vehicle newVehicle = new Vehicle { Make = "Peugeot", Model = "3008" };

        dataAccess.InsertPerson(newPerson);
        dataAccess.InsertVehicle(newVehicle);
    }

    static void InsuranceDataAccessExample()
    {
        // We define our database connection string, this is based on server name, and the name of the Database
        string connectionString = "Data Source = localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog = InsuranceBrokerDatabase; TrustServerCertificate=True";
        InsuranceDataAccess dataAccess = new InsuranceDataAccess(connectionString);

        // Fetch and display persons
        List<Person> persons = dataAccess.GetPersons();
        Console.WriteLine("Persons:");
        foreach (Person person in persons)
        {
            Console.WriteLine($"ID: {person.ID}, Name: {person.FirstName} {person.LastName}");
        }

        // Fetch and display vehicles
        List<Vehicle> vehicles = dataAccess.GetVehicles();
        Console.WriteLine("\nVehicles:");
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine($"ID: {vehicle.ID}, Make: {vehicle.Make}, Model: {vehicle.Model}");
        }
    }

    static void InsurancePolicyExample()
    {
        // Creating instances of Vehicle and Person
        Vehicle car = new Vehicle { ID = "V123", Make = "Toyota", Model = "Corolla" };
        Person owner = new Person { ID = "P456", FirstName = "John", LastName = "Doe" };

        // Creating instances of InsurancePolicy for each entity
        InsurancePolicy carPolicy = new InsurancePolicy
        {
            InsuredEntity = car,
            DurationMonths = 12,
            MaxInsuredValue = 10000m // Using 'm' to indicate decimal
        };

        InsurancePolicy ownerPolicy = new InsurancePolicy
        {
            InsuredEntity = owner,
            DurationMonths = 24,
            MaxInsuredValue = 200000m
        };

        // Displaying policy details demonstrating polymorphism
        Console.WriteLine("Car Insurance Policy:");
        carPolicy.DisplayPolicyDetails();

        Console.WriteLine("\nOwner Insurance Policy:");
        ownerPolicy.DisplayPolicyDetails();
    }

    static void ArrayExample()
    {
        // Array example
        int[] arrayOfInts = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Array elements:");
        foreach (int i in arrayOfInts)
        {
            Console.WriteLine(i);
        }
    }
    static void ListExample()
    {
        // List example
        List<int> listOfInts = new List<int> { 6, 7, 8, 9, 10 };
        Console.WriteLine("\nList elements:");
        foreach (int i in listOfInts)
        {
            Console.WriteLine(i);
        }
    }

    static IEnumerable<int> GetNumbers() 
    { 
        for (int i = 16; i <= 20; i++)
        {
            yield return i;
        }
    }
    static void IEnumerableExample()
    {
        // IEnumerable example
        IEnumerable<int> numbers = GetNumbers();
        Console.WriteLine("\nIEnumerable elements:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }static void DeferredExecutionExample()
    {
        // Deferred Execution example with IEnumerable and LINQ
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // Define a LINQ query on the list for deferred execution
        IEnumerable<int> evenNumbersQuery = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("\nList has been created, and even numbers query has been defined.");
        Console.WriteLine("Query has not run yet.");
        // Change the original data before executing the query
        numbers.Add(12);
        // Adding a new even number to the list
        Console.WriteLine("Added a new even number (12) to the list.");
        // Execute the query by iterating over it
        Console.WriteLine("\nEven numbers after deferred execution:");
        foreach (var n in evenNumbersQuery)
        {
            Console.WriteLine(n);
            // Now, the query actually executes
        }
    }
    static void HashSetExample()
    {
        // HashSet example (another collection that implements IEnumerable)
        HashSet<int> hashSet = new HashSet<int>() { 11, 12, 13, 14, 15 };
        Console.WriteLine("\nHashSet elements:");
        foreach (int item in hashSet)
        {
            Console.WriteLine(item);
        }
    }

    static void DictionaryExample()
    {
        // Creating a new Dictionary
        Dictionary<string, int> carInventory = new Dictionary<string, int>();

        // Adding key-value pairs to the Dictionary
        carInventory.Add("Toyota", 5);
        carInventory.Add("Honda", 10);
        carInventory.Add("Ford", 3);

        // Accessing a value using its key
        Console.WriteLine("Number of Toyotas: " + carInventory["Toyota"]);

        // Updating a value
        carInventory["Toyota"] = 8;
        Console.WriteLine("Updated number of Toyotas: " + carInventory["Toyota"]);

        // Iterating over the Dictionary
        Console.WriteLine("Cars in the inventory:");
        foreach (KeyValuePair<string, int> item in carInventory)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

}
