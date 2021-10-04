using BenganBowlingOnur.Billing;
using BenganBowlingOnur.Managers;
using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Factories
{
    public class MemberFactory
    {
        private Member _member;
        private readonly double _memberFee;

        public MemberFactory(double memberFee)
        {
            _memberFee = memberFee;
        }

        public Member CreateMember(string name, string address, bool paidMembership)
        {
            _member = new Member(name, address, paidMembership);

            var resultManager = ResultManager.Instance();
            resultManager.Members.Add(_member);

            if (paidMembership) return _member;
            var billingInterface = ForDream.Instance();
            billingInterface.NewInvoice(_member, _memberFee);
            _member.PaidMembership = true;
            Console.WriteLine("Membership invoice created for: " + _member.Name);

            return _member;
        }
    }
}
