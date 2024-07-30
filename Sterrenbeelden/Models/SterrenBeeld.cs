using System.Globalization;

namespace Sterrenbeelden.Models;

public class SterrenBeeld
{
    public required string SterrenBeeldNaam { get; set; }
    public DateOnly BeginDatum { get; set; }
    public DateOnly Einddatum { get; set; }

    public override string ToString()
    {
        CultureInfo culture = new CultureInfo("nl-BE");

        return $"{SterrenBeeldNaam}" +
                   $"\n{BeginDatum.ToString(culture.DateTimeFormat.MonthDayPattern, culture)}" +
                   $" - " +
                   $"{Einddatum.ToString(culture.DateTimeFormat.MonthDayPattern, culture)}\n\n";
    }
}
