using BenganBowlingOnur.Billing;
using BenganBowlingOnur.Interfaces;
using BenganBowlingOnur.Managers;
using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Builders
{
    public class MatchBuilder : IBuilder
    {
        private Match _match;
        private readonly double _matchFee;

        public MatchBuilder(double matchFee)
        {
            _matchFee = matchFee;
        }

        public void CreateMatch(Member playerOne, Member playerTwo)
        {
            _match = new Match(playerOne, playerTwo);
            var resultManager = ResultManager.Instance();
            resultManager.Matches.Add(_match);
        }

        public void CreateInvoice(Member playerOne, Member playerTwo)
        {
            var forDream = ForDream.Instance();
            forDream.NewInvoice(playerOne, _matchFee);
            forDream.NewInvoice(playerTwo, _matchFee);
        }

        public Match GetResult()
        {
            return _match;
        }
    }
}
