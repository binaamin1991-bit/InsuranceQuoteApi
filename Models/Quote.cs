using System;
using System.Collections.Generic;

namespace QuotingApi.Models
{
    public class Quote
    {
        public Guid Id { get; set; }
        public int Term { get; set; }
        public decimal SumInsured { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CompanyQuote> Premiums { get; set; } = new();
    }
}
