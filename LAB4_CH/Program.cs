using System;
using System.Collections;
using System.Collections.Generic;
namespace LAB4_CH
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam RT1 = new ResearchTeam("Armada", 5, "MATH", TimeFrame.TwoYears);
            ResearchTeam RT2 = new ResearchTeam("Formula", 2, "RACE", TimeFrame.Year);

            ResearchTeamCollection<String> RTC1 = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);
            RTC1.CollectionName = "First";
            RTC1.AddResearchTeams(RT1);

            ResearchTeamCollection<String> RTC2 = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);
            RTC2.CollectionName = "Second";
            RTC2.AddResearchTeams(RT2);

            TeamsJournal<String> teamsJournal = new TeamsJournal<String>();
            RTC1.ResearchTeamsChanged += teamsJournal.ResearchTeamsChangedHandler;
            RTC2.ResearchTeamsChanged += teamsJournal.ResearchTeamsChangedHandler;

            RTC1.AddResearchTeams(new ResearchTeam());
            RTC2.AddResearchTeams(new ResearchTeam());

            RTC1.Teams["Armada"].Duration = TimeFrame.Long;
            RTC2.Teams["Formula"].Reg_num = 33;

            RTC2.Remove(RT2);
            try
            {
                RTC2.Teams["Formula"].Reg_num = 44;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString() + "\n");
            }

            ResearchTeam RT3 = new ResearchTeam("MIET", 5, "Institute", TimeFrame.Long);
            RTC1.Replace(RT1, RT3);
            try
            {
                RTC1.Teams["Armada"].Reg_num = 3;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            Console.WriteLine(teamsJournal);
        }
    }
}