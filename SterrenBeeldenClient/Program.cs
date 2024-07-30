using Sterrenbeelden.Models;
using System.Net;
Console.Write("Geef de dag en maand van uw geboortedatum (dag-maand): ");

string datum = Console.ReadLine()!;

using var client = new HttpClient();

var response = await client.GetAsync($"http://localhost:5000/sterrenbeelden/{datum}");

switch (response.StatusCode)
{
    case HttpStatusCode.OK:

        Console.WriteLine(await response.Content.ReadAsStringAsync());
        break;
    case HttpStatusCode.NotFound:
        Console.WriteLine("Sterrenbeeld niet gevonden.");
        break;
    default:
        Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
        break;
}Console.WriteLine("Druk op een toets op de programma te beëindigen.");
Console.WriteLine();
Console.ReadKey();