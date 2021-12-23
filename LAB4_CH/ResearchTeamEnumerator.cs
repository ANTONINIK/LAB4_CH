using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB4_CH
{
    class ResearchTeamEnumerator : IEnumerator
    {
        public List<Paper> papers;

        public List<Person> persons;

        int position = -1;
        public ResearchTeamEnumerator(List<Paper> papers, List<Person> persons)
        {
            this.papers = papers;
            this.persons = persons;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= persons.Count) throw new IndexOutOfRangeException();
                return persons[position];
            }
        }
        public bool MoveNext()
        {
            while (position < persons.Count - 1)
            {
                position++;
                for (int i = 0; i < papers.Count; i++)
                {
                    if ((Person)Current == papers[i].author)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
