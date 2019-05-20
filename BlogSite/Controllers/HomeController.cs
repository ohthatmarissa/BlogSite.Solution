using System;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
