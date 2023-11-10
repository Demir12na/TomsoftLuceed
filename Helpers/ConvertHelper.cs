using System.Text.Json;
using TomsoftLuceed.Models;

namespace TomsoftLuceed.Helpers
{
    public static class ConvertHelper
    {

        public static List<GetListOfItemsByPartOfNameResItem> ExtractItemIdAndNameFromJson(string json)
        {
            List<GetListOfItemsByPartOfNameResItem> items = new List<GetListOfItemsByPartOfNameResItem>();

            JsonDocument doc = JsonDocument.Parse(json);

            JsonElement root = doc.RootElement;
            JsonElement itemsArray = root.GetProperty("result")[0].GetProperty("artikli");

            // Extract id and name values
            foreach (JsonElement item in itemsArray.EnumerateArray())
            {
                GetListOfItemsByPartOfNameResItem itemToAdd = new GetListOfItemsByPartOfNameResItem
                {
                    Id = item.GetProperty("artikl_uid").GetString(),
                    Name = item.GetProperty("naziv").GetString(),
                };

                items.Add(itemToAdd);
            }

            return items;
        }

    }
}
