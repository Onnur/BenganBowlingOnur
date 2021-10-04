using BenganBowlingOnur.Billing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Models
{
    public class Member
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool PaidMembership { get; set; }

        public Member(string name, string address, bool paidMembership)
        {
            Name = name;
            Address = address;
            PaidMembership = paidMembership;

            if (!paidMembership)
            {
                var forDream = ForDream.Instance();
            }
        }
    }
}