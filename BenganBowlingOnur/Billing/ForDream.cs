using BenganBowlingOnur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenganBowlingOnur.Billing
{
    //ForDream är mitt bokförings namn
    class ForDream
    {
        private static ForDream _instance;
        private readonly List<Invoice> _invoices;

        public ForDream()
        {
            _invoices = new List<Invoice>();
        }

        public static ForDream Instance()
        {
            return _instance ?? (_instance = new ForDream());
        }

        public void NewInvoice(Member member, double debitAmount)
        {
            _invoices.Add(new Invoice(member, debitAmount));
        }

        public List<string> ExportInvoices()
        {
            var invoiceExport = new List<string>();

            Console.WriteLine("Exporting saved invoices...");
            foreach (var invoice in _invoices)
            {
                invoiceExport.Add(invoice.ToString());
                Console.WriteLine(invoice.ToString());
            }

            return invoiceExport;
        }
    }
}
