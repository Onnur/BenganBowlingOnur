using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Billing
{
    //faktura
    public class Invoice
    {
        private readonly Member _member;
        private readonly double _amount;

        public Invoice(Member member, double amount)
        {
            _member = member;
            _amount = amount;
        }

        public override string ToString()
        {
            return "Name: " + _member.Name + " Address: " + _member.Address + " Amount: " + _amount;
        }
    }
}
