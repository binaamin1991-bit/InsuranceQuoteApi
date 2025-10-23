using QuotingApi.Models;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace QuotingApi.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ConcurrentDictionary<Guid, Quote> _quotes = new();

        private static readonly string[] CompanyCodes = { "AL01", "BNK2", "SAFE", "AEQX" };

        public Guid CreateQuote(QuoteRequest request)
        {
            var id = Guid.NewGuid();

            var premiums = CompanyCodes.Select(code => new CompanyQuote
            {
                CompanyCode = code,
                Premium = GeneratePremium(id, code, request.SumInsured, request.Term)
            }).ToList();

            var quote = new Quote
            {
                Id = id,
                Term = request.Term,
                SumInsured = request.SumInsured,
                CreatedAt = DateTime.UtcNow,
                Premiums = premiums
            };

            _quotes[id] = quote;
            return id;
        }

        public Quote? GetQuote(Guid id)
        {
            _quotes.TryGetValue(id, out var quote);
            return quote;
        }

        private decimal GeneratePremium(Guid id, string companyCode, decimal sumInsured, int term)
        {
            var input = id.ToString() + companyCode;
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            int v = BitConverter.ToInt32(hash, 0) & 0x7fffffff;

            var baseRate = 0.005m + (v % 2000) / 10000m;
            var premium = Math.Round((sumInsured * baseRate) / Math.Max(1, term), 2);
            return premium;
        }
    }
}

