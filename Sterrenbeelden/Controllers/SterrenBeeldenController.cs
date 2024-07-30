using Microsoft.AspNetCore.Mvc;
using Sterrenbeelden.Models;
using Sterrenbeelden.Services;
using System.Text;
using System.Text.Json;

namespace Sterrenbeelden.Controllers;

[Route("sterrenbeelden"), ApiController]
public class SterrenBeeldenController(SterrenBeeldService service) : ControllerBase
{
    public ActionResult SterrenBeelden()
    {
        StringBuilder? sb = new StringBuilder();

        foreach (var sterrenbeeld in service.GetAllSterrenBeelden())
        {
            sb.Append(sterrenbeeld?.ToString());
        }
        return base.Ok(sb.ToString());
    }

    [HttpGet("{dag}-{maand}")]
    public ActionResult GetSterrenBeelden(int dag, int maand)
    {
        if(maand <= 12 && dag < DateTime.DaysInMonth(DateTime.Now.Year, maand))
        {
            SterrenBeeld sterrenBeeld = service.GetSterrenBeeldByDate(dag, maand)!;
            return base.Ok(sterrenBeeld.ToString());
        }

        return base.NotFound();
    }
}
