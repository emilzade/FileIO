namespace FileIO.Models
{
    public class Person
    {
        private static int _idCounter;
        private string _name;
        private string _surname;
        private int _age;
        public int Id { get; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        static Person()
        {
            _idCounter = 0;
        }

        public Person(string name, string surname, int age)
        {
            
            Id = ++_idCounter;
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | Surname {Surname} | Age: | {Age} ";
        }
    }
}