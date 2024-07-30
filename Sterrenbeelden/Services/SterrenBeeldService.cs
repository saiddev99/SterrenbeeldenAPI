using Sterrenbeelden.Models;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sterrenbeelden.Services;

public class SterrenBeeldService
{
    private List<SterrenBeeld> SterrenBeelden { get; set; }
    public SterrenBeeldService()
    {
        SterrenBeelden = new()
        {
            new SterrenBeeld {SterrenBeeldNaam = "Steenbok", BeginDatum=new DateOnly(DateTime.Now.Year,12,22), Einddatum = new DateOnly(DateTime.Now.Year + 1,1,19)},

            new SterrenBeeld {SterrenBeeldNaam = "Waterman", BeginDatum=new DateOnly(DateTime.Now.Year,1,20), Einddatum = new DateOnly(DateTime.Now.Year,2,18)},

            new SterrenBeeld {SterrenBeeldNaam = "Vissen", BeginDatum=new DateOnly(DateTime.Now.Year,2,19), Einddatum = new DateOnly(DateTime.Now.Year,3,20)},

            new SterrenBeeld {SterrenBeeldNaam = "Ram", BeginDatum=new DateOnly(DateTime.Now.Year,3,21), Einddatum = new DateOnly(DateTime.Now.Year,4,19)},

            new SterrenBeeld {SterrenBeeldNaam = "Stier", BeginDatum=new DateOnly(DateTime.Now.Year,4,20), Einddatum = new DateOnly(DateTime.Now.Year,5,20)},

            new SterrenBeeld {SterrenBeeldNaam = "Tweelingen", BeginDatum=new DateOnly(DateTime.Now.Year,5,21), Einddatum = new DateOnly(DateTime.Now.Year,6,20)},

            new SterrenBeeld {SterrenBeeldNaam = "Kreeft", BeginDatum=new DateOnly(DateTime.Now.Year,6,21), Einddatum = new DateOnly(DateTime.Now.Year,7,22)},

            new SterrenBeeld {SterrenBeeldNaam = "Leeuw", BeginDatum=new DateOnly(DateTime.Now.Year,7,23), Einddatum = new DateOnly(DateTime.Now.Year,8,22)},

            new SterrenBeeld {SterrenBeeldNaam = "Maagd", BeginDatum=new DateOnly(DateTime.Now.Year,8,23), Einddatum = new DateOnly(DateTime.Now.Year,9,22)},

            new SterrenBeeld {SterrenBeeldNaam = "Weegscaal", BeginDatum=new DateOnly(DateTime.Now.Year,9,23), Einddatum = new DateOnly(DateTime.Now.Year,10,22)},

            new SterrenBeeld {SterrenBeeldNaam = "Schorpioen", BeginDatum=new DateOnly(DateTime.Now.Year,10,23), Einddatum = new DateOnly(DateTime.Now.Year,11,21)},

            new SterrenBeeld {SterrenBeeldNaam = "Boogschutter", BeginDatum=new DateOnly(DateTime.Now.Year,11,22), Einddatum = new DateOnly(DateTime.Now.Year,12,21)},
        };
    }

    public List<SterrenBeeld?> GetAllSterrenBeelden()
    {
        return SterrenBeelden;
    }

    public SterrenBeeld? GetSterrenBeeldByDate(int dag, int maand)
    {
        DateOnly selectedDate = new DateOnly(DateTime.Now.Year, maand, dag);
        DateOnly selectedDateNextYear;

        if (!DateTime.IsLeapYear(selectedDate.Year + 1) && dag == 29 && maand == 2)
        {
            selectedDateNextYear = new DateOnly(DateTime.Now.Year + 1, maand, dag - 1);
        }
        else
        {
            selectedDateNextYear = new DateOnly(DateTime.Now.Year + 1, maand, dag);
        }

        if (selectedDate >= SterrenBeelden[0].BeginDatum && selectedDate <= SterrenBeelden[0].Einddatum || selectedDateNextYear >= SterrenBeelden[0].BeginDatum && selectedDateNextYear <= SterrenBeelden[0].Einddatum)
        {
            return SterrenBeelden[0];
        }

        return SterrenBeelden.FirstOrDefault(x => selectedDate >= x.BeginDatum && selectedDate <= x.Einddatum);
    }
}
