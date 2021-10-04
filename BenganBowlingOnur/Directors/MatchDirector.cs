using BenganBowlingOnur.Interfaces;
using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Directors
{
    public class MatchDirector
    {
        public void Construct(IBuilder builder, Member playerOne, Member playerTwo)
        {
            builder.CreateMatch(playerOne, playerTwo);
            builder.CreateInvoice(playerOne, playerTwo);
        }
    }
}
