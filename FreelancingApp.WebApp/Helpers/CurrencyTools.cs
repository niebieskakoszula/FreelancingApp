using System.Globalization;

namespace FreelancingApp.WebApp.Helpers
{
    public static class CurrencyTools
    {
        private static readonly IDictionary<string, string> _map;
        static CurrencyTools()
        {
            _map = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture => {
                    try
                    {
                        return new RegionInfo(culture.Name);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(ri => ri != null)
                .GroupBy(ri => ri!.ISOCurrencySymbol)
                .ToDictionary(x => x.Key, x => x.First()!.CurrencySymbol);
        }
        public static IDictionary<string, string> GetCurrencyMap()
        {
            return _map;
        }
        public static bool TryGetCurrencySymbol(
                              string ISOCurrencySymbol,
                              out string symbol)
        {
            return _map.TryGetValue(ISOCurrencySymbol, out symbol!);
        }
    }
}
