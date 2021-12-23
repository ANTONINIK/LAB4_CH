using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LAB4_CH
{
    delegate TKey KeySelector<TKey> (ResearchTeam rt);
    delegate void ResearchTeamsChangedHandler<TKey>(object source, ResearchTeamsChangedEventArgs<TKey> args);
    class ResearchTeamCollection<TKey>
    {
        public string CollectionName { get; set; }
        public Dictionary<TKey, ResearchTeam> Teams;
        private KeySelector<TKey> KeySelector;

        public event ResearchTeamsChangedHandler<TKey> ResearchTeamsChanged;

        public ResearchTeamCollection(KeySelector<TKey> keySelector)
        {
            Teams = new Dictionary<TKey, ResearchTeam>();
            KeySelector = keySelector;
        }

        void PropertyChanging(object source, PropertyChangedEventArgs args)
        {
            if(source != null && args != null)
            ResearchTeamsChanged.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Property, args.PropertyName, (source as ResearchTeam).Reg_num));
        }

        internal static string GenerateKey(ResearchTeam rt)
        {
            return rt.Name;
        }

        public void AddDefaults()
        {

            ResearchTeam item = new ResearchTeam();

                TKey key = KeySelector(item);
                if (!Teams.ContainsKey(key))
                {
                    Teams.Add(key, item);
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Add, "AddResearchTeams", item.Reg_num));
                }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {

            foreach (ResearchTeam item in researchTeams)
            {

                TKey key = KeySelector(item);
                if (!Teams.ContainsKey(key))
                {
                    Teams.Add(key, item);
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Add, "AddResearchTeams", item.Reg_num));
                }
            }
        }

        public override string ToString()
        {
            string str = $"Здесь содержится {Teams.Count} ResearchTeams: \n";
            foreach (ResearchTeam info in Teams.Values)
            {
                str += info.ToString();
            }
            return str;
        }

        public virtual string ToShortString()
        {
            string str = $"Здесь содержится {Teams.Count} ResearchTeams: \n";
            foreach (ResearchTeam info in Teams.Values)
            {
                str += info.ToShortString();
            }
            return str;
        }
        public DateTime GetLastPaper
        {
            get
            {
                if (Teams.Count > 0) return Teams.Values.Max(rest => rest.LastPaper());
                return new DateTime();

            }
        }
        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> TimeFrameGroup
        {
            get
            {
                return Teams.GroupBy(obj => obj.Value.Duration);
            }
        }
        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameValue(TimeFrame value)
        {
            return Teams.Where(obj => obj.Value.Duration == value);
        }
        public bool Remove(ResearchTeam rt)
        {
            foreach (TKey key in Teams.Keys)
            {
                if (Teams[key].Equals(rt))
                {
                    Teams.Remove(key);
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName,Revision.Remove, "", rt.Reg_num));
                    return true;
                }
            }

            return false;
        }
        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            foreach (TKey key in Teams.Keys)
            {
                if (Teams[key].Equals(rtold))
                {
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Replace, "", rtold.Reg_num));
                    Teams[key] = rtnew;
                    return true;
                }
            }
            return false;
        }
    }
}
