using QuotingApi.Models;

namespace QuotingApi.Services
{
    public interface IQuoteService
    {
        Guid CreateQuote(QuoteRequest request);
        Quote? GetQuote(Guid id);
    }
}
