using System.Text;
using TomsoftLuceed.Helpers;
using TomsoftLuceed.IServices;
using TomsoftLuceed.Models;

namespace TomsoftLuceed.Services
{
    public class TomsoftLuceedService : ITomsoftLuceedService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TomsoftLuceedService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// GetListOfItemsBypartOfNameAsync
        /// </summary>
        /// <param name="pjUid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>List of GetListOfItemsByPartOfNameResItem</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<GetListOfItemsByPartOfNameResItem>> GetListOfItemsBypartOfNameAsync(string? partOfName)
        {
            try
            {
                string content = "";

                var url = $"http://apidemo.luceed.hr/datasnap/rest/artikli/naziv/{partOfName}";

                var httpClient = _httpClientFactory.CreateClient("LuceedApiClient");

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream, Encoding.UTF8))
                    {
                        content = await streamReader.ReadToEndAsync();
                    }
                }
                else
                {
                    throw new Exception("Error while getting data for canculation of turnover by payment types");
                }

                return ConvertHelper.ExtractItemIdAndNameFromJson(content);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetCalculationOfTurnoverByPaymentTypesAsync
        /// </summary>
        /// <param name="pjUid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetCalculationOfTurnoverByPaymentTypesAsync(string pjUid, DateTime fromDate, DateTime? toDate)
        {
            try
            {
                string fromDateFormatted = FormatHelper.FormatDate(fromDate);
                string toDateFormated = toDate.HasValue ? FormatHelper.FormatDate(toDate.Value) : null;

                var url = $"http://apidemo.luceed.hr/datasnap/rest/mpobracun/placanja/{pjUid}/{fromDateFormatted}/{toDateFormated}";

                var httpClient = _httpClientFactory.CreateClient("LuceedApiClient");

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream, Encoding.UTF8))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
                else
                {
                    throw new Exception("Error while getting data for canculation of turnover by payment types");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetCalculationOfTurnoverByItemsAsync
        /// </summary>
        /// <param name="pjUid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetCalculationOfTurnoverByItemsAsync(string pjUid, DateTime fromDate, DateTime? toDate)
        {
            try
            {
                string fromDateFormatted = FormatHelper.FormatDate(fromDate);
                string toDateFormated = toDate.HasValue ? FormatHelper.FormatDate(toDate.Value) : null;

                var url = $"http://apidemo.luceed.hr/datasnap/rest/mpobracun/artikli/{pjUid}/{fromDateFormatted}/{toDateFormated}";

                var httpClient = _httpClientFactory.CreateClient("LuceedApiClient");

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream, Encoding.UTF8))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
                else
                {
                    throw new Exception("Error while getting data for canculation of turnover by items");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
