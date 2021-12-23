using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_CH
{
    internal class TeamsJournalEntry
    {
        public string CollectionName { get; set; }

        public Revision typeEvent { get; set; }

        public int reg_num { get; set; }

        public string PropertyName { get; set; }

        public TeamsJournalEntry(string CollectionName, Revision typeEvent, string PropertyName, int reg_num)
        {
            this.CollectionName = CollectionName;
            this.typeEvent = typeEvent;
            this.reg_num = reg_num;
            this.PropertyName = PropertyName;
        }

        public override string ToString()
        {
            return CollectionName.ToString() + " " + typeEvent.ToString() + " " + reg_num.ToString() + " " + PropertyName.ToString();
        }

    }
}
