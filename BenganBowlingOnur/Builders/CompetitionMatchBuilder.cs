using BenganBowlingOnur.Billing;
using BenganBowlingOnur.Interfaces;
using BenganBowlingOnur.Managers;
using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Builders
{
    public class CompetitionMatchBuilder : IBuilder
    {
        private Match _match;
        private readonly Competition _competition;
        private readonly double _matchFee;

        public CompetitionMatchBuilder(Competition competition, double matchFee)
        {
            _competition = competition;
            _matchFee = matchFee;
        }


        public void CreateMatch(Member playerOne, Member playerTwo)
        {
            _match = new Match(playerOne, playerTwo);

            _competition.AddMatch(_match);

            var resultManager = ResultManager.Instance();
            resultManager.Matches.Add(_match);
        }

        public void CreateInvoice(Member playerOne, Member playerTwo)
        {
            var forDream = ForDream.Instance();

            if (!_competition.IsParticipant(playerOne))
            {
                forDream.NewInvoice(playerOne, _competition.Fee);
                _competition.AddParticipant(playerOne);
            }
            if (!_competition.IsParticipant(playerTwo))
            {
                forDream.NewInvoice(playerTwo, _competition.Fee);
                _competition.AddParticipant(playerTwo);
            }

            forDream.NewInvoice(playerOne, _matchFee);
            forDream.NewInvoice(playerTwo, _matchFee);
        }

        public Match GetResult()
        {
            return _match;
        }
    }
}
