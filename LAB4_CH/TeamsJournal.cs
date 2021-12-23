using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_CH
{
    internal class TeamsJournal<TKey>
    {
        private List<TeamsJournalEntry> teamsJournalEntries = new();

        public override string ToString()
        {
            string str = "Teams Journal" + "\n";
            foreach (TeamsJournalEntry entry in teamsJournalEntries)
            {
                str+= entry.ToString() + "\n";
            }

            return str;
        }

       public void ResearchTeamsChangedHandler(object sendler, ResearchTeamsChangedEventArgs<TKey> outObject) 
        {
            teamsJournalEntries.Add(new TeamsJournalEntry(outObject.CollectionName, outObject.typeEvent, outObject.PropertyName, outObject.reg_num));
        }
    }
}
