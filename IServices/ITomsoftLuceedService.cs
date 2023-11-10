using TomsoftLuceed.Models;

namespace TomsoftLuceed.IServices
{
    public interface ITomsoftLuceedService
    {
        Task<List<GetListOfItemsByPartOfNameResItem>> GetListOfItemsBypartOfNameAsync(string? partOfName);
        Task<string> GetCalculationOfTurnoverByPaymentTypesAsync(string pjUid, DateTime fromDate, DateTime? toDate);
        Task<string> GetCalculationOfTurnoverByItemsAsync(string pjUid, DateTime fromDate, DateTime? toDate);
    }
}
