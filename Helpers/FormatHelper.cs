namespace TomsoftLuceed.Helpers
{
    public static class FormatHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString("d.M.yyyy");
        }
    }
}
