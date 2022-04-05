using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FileIO;
using System.Text.Json.Serialization;

namespace FileIO.Models
{
    public class People
    {
        string rootDir = @"C:\Users\Scc\source\repos\FileIO\FileIO\";
        public void CreateNewPerson()
        {
            Console.Write("Enter name: ");
            string personName = Console.ReadLine();
            Console.Write("Enter surname: ");
            string personSurname = Console.ReadLine();
            AgeInput:
            Console.Write("Enter age: ");
            string ageInput = Console.ReadLine();
            int personAge;
            try
            {
                personAge = Convert.ToInt32(ageInput);
                if (personAge <= 1 || personAge >= 80)
                {
                    goto AgeInput;
                }
            }
            catch (Exception e)
            {
                goto AgeInput;
            }
            string jsonPerson = JsonSerializer.Serialize(new Person(personName, personSurname, personAge));
            Write(rootDir , jsonPerson);
            Console.WriteLine("Person has been successfully created !");
        }
        public void ShowPeopleDetailed()
        {
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person person = JsonSerializer.Deserialize<Person>(item);
                people.Add(person); 
            } 
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        
        public void FindPersonByName(string name)
        {
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person person = JsonSerializer.Deserialize<Person>(item);
                people.Add(person); 
            } 
            foreach (var person in people)
            {
                if (person.Name == name)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
        public void SearchPerson(string value)
        {
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person person = JsonSerializer.Deserialize<Person>(item);
                people.Add(person); 
            } 
            foreach (var person in people)
            {
                if (person.Name.Contains(value))
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
        public void FindAllPersonsByAgeRange(int startPoint , int endPoint)
        {
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person person = JsonSerializer.Deserialize<Person>(item);
                people.Add(person); 
            } 
            foreach (var person in people)
            {
                if (person.Age >= startPoint && person.Age <= endPoint)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
        
        public static void Write(string dir,string text)
        {
            string fileDir = CreateDirectory(dir);

            using (var textWriter = new StreamWriter(fileDir, true))
            {
                textWriter.WriteLine(text);
            }
        }
        public static IEnumerable<string> Read(string dir)
        {
            string fileDir = CreateDirectory(dir);
            IEnumerable<string> lines = File.ReadLines(fileDir);
            return lines;
        }
        public static string CreateDirectory(string dir)
        {
            string contentDir = Path.Combine(dir, "Content");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileDir = Path.Combine(contentDir, "Db.txt");
            if (!File.Exists(fileDir))
            {
                File.Create(fileDir);
            }

            return fileDir;
        }
    }
}