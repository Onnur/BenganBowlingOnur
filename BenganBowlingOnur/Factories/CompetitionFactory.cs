using BenganBowlingOnur.Managers;
using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Factories
{
    public class CompetitionFactory
    {
        private Competition _competition;

        public Competition CreateCompetition(string name, DateTime startDate, DateTime endDate, double competitionFee)
        {
            _competition = new Competition(name, startDate, endDate, competitionFee);

            var resultManager = ResultManager.Instance();
            resultManager.Competitions.Add(_competition);

            return _competition;
        }
    }
}
