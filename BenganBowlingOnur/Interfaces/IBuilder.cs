using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Interfaces
{
    public interface IBuilder
    {
        void CreateMatch(Member playerOne, Member playerTwo);
        void CreateInvoice(Member playerOne, Member playerTwo);
        Match GetResult();
    }
}
