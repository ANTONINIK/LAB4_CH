using System;

namespace LAB4_CH
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }
        public Person() : this("Anton", "Maryanskiy", new DateTime(2002, 5, 18)) { }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public int Year
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + Birthday.ToShortDateString();
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   name == person.name &&
                   surname == person.surname &&
                   birthday == person.birthday;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name, surname, birthday);
        }
        public static bool operator ==(Person ob1, Person ob2)
        {
            return ob1.name == ob2.name && ob1.surname == ob2.surname && ob1.birthday == ob2.birthday;
        }
        public static bool operator !=(Person ob1, Person ob2)
        {
            return ob1.name != ob2.name || ob1.surname != ob2.surname || ob1.birthday != ob2.birthday;
        }
        public virtual object DeepCopy()
        {
            return new Person(name, surname, birthday);
        }
    }
}