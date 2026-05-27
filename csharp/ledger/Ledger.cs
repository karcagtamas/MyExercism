using System.Globalization;

public class LedgerEntry(DateTime date, string desc, decimal chg)
{
    public DateTime Date { get; } = date;
    public string Desc { get; } = desc;
    public decimal Chg { get; } = chg;
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng) => new(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        int curNeg = 0;
        string curSymb = cur switch
        {
            "USD" => "$",
            "EUR" => "€",
            _ => throw new ArgumentException("Invalid currency"),
        };

        string? datPat;
        switch (loc)
        {
            case "en-US":
                datPat = "MM/dd/yyyy";
                break;
            case "nl-NL":
                datPat = "dd/MM/yyyy";
                curNeg = 12;
                break;
            default:
                throw new ArgumentException("Invalid currency");
        }

        var culture = new CultureInfo(loc, false);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
        return culture;
    }

    private static string PrintHead(string loc) => loc switch
    {
        "en-US" => "Date       | Description               | Change       ",
        "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
        _ => throw new ArgumentException("Invalid locale"),
    };

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc) => desc.Length > 25 ? $"{desc[..22]}..." : desc;

    private static string Change(IFormatProvider culture, decimal cgh)
    {
        var change = cgh.ToString("C", culture);

        return cgh < 0.0m && !change.Contains('-') ? change : change + " ";
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) => $"{Date(culture, entry.Date)} | {string.Format("{0,-25}", Description(entry.Desc))} | {string.Format("{0,13}", Change(culture, entry.Chg))}";


    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
        var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

        return [.. neg, .. post];
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = "";
        formatted += PrintHead(locale);

        var culture = CreateCulture(currency, locale);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);

            for (var i = 0; i < entriesForOutput.Count(); i++)
            {
                formatted += "\n" + PrintEntry(culture, entriesForOutput.Skip(i).First());
            }
        }

        return formatted;
    }
}
