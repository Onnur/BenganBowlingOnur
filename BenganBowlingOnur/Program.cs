using BenganBowlingOnur.Billing;
using BenganBowlingOnur.Builders;
using BenganBowlingOnur.Directors;
using BenganBowlingOnur.Factories;
using BenganBowlingOnur.Managers;
using System;

namespace BenganBowlingOnur
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberFactory = new MemberFactory(400);
            for (var i = 0; i < 11; i++)
            {
                memberFactory.CreateMember("Test Spelare" + i, "Test Gata" + i, true);
            }

            var competitionFactory = new CompetitionFactory();
            var testCompetition = competitionFactory.CreateCompetition("Test Competition", DateTime.Now, DateTime.Now.AddDays(7), 150);


            var matchDirector = new MatchDirector();
            var testCupGameMatchBuilder = new CompetitionMatchBuilder(testCompetition, 100);

            Console.WriteLine("Competition games:");
            for (var j = 0; j < 11; j++)
            {
                for (var i = j + 1; i < 11; i++)
                {
                    var player = ResultManager.Instance().Members[j];
                    var opponent = ResultManager.Instance().Members[i];

                    matchDirector.Construct(testCupGameMatchBuilder, player, opponent);
                    testCupGameMatchBuilder.GetResult().GeneratePlayerScores();
                }
            }


            Console.WriteLine();
            Console.WriteLine("Champion playing games...");
            var champ = memberFactory.CreateMember("Winner", "Winner Street", true);
            var loser = memberFactory.CreateMember("Loser", "Loser Street", true);

            var standaloneMatchBuilder = new MatchBuilder(100);
            for (var i = 0; i < 12; i++)
            {
                matchDirector.Construct(standaloneMatchBuilder, champ, loser);
                var testMatch = standaloneMatchBuilder.GetResult();
                testMatch.SetPlayerOneScore(100, 100, 100);
                testMatch.SetPlayerTwoScore(50, 50, 50);
            }


            var resultManager = ResultManager.Instance();
            resultManager.GetCompetitionResults(testCompetition);
            resultManager.GetYearChampion(DateTime.Now);


            Console.WriteLine();
            Console.WriteLine("----------");
            var forDream = ForDream.Instance();
            forDream.ExportInvoices();

            Console.WriteLine();
            Console.WriteLine("Tryck valfritt knapp för att stänga..");
            Console.ReadLine();
        }
    }
}
