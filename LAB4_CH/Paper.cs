using System;
using System.Collections.Generic;

namespace LAB4_CH
{
    class Paper : IComparable, IComparer<Paper>
    {
        public string name { get; set; }
        public Person author { get; set; }
        public DateTime publictime { get; set; }
        public Paper(string nameValue, Person authorValue, DateTime publictimeValue)
        {
            name = nameValue;
            author = authorValue;
            publictime = publictimeValue;
        }
        public Paper() : this("Integrals", new Person(), new DateTime(2021, 12, 9)) { }
        public override string ToString()
        {
            return name + " " + author + " " + publictime.ToShortDateString();
        }
        public override bool Equals(object obj)
        {
            if (obj != null)
            return obj is Paper paper &&
                   name == paper.name &&
                   author.Equals(paper.author) &&
                   publictime == paper.publictime;
            else return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name, author, publictime);
        }
        public static bool operator ==(Paper ob1, Paper ob2)
        {
            return ob1.name == ob2.name && ob1.author == ob2.author && ob1.publictime == ob2.publictime;
        }
        public static bool operator !=(Paper ob1, Paper ob2)
        {
            return ob1.name != ob2.name || ob1.author != ob2.author || ob1.publictime != ob2.publictime;
        }
        public virtual object DeepCopy()
        {
            return new Paper(name, (Person)author.DeepCopy(), publictime);
        }
        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            Paper otherPaper = obj as Paper;
            return !(otherPaper is null) ? publictime.CompareTo(otherPaper.publictime) : throw new ArgumentException("Object is not a Paper");
        }
        int IComparer<Paper>.Compare(Paper p1, Paper p2)
        {
            return p1.name.CompareTo(p2.name);
        }
    }
}
