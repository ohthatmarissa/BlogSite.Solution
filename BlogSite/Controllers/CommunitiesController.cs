using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BlogSite.Controllers
{
  public class CommunitiesController : Controller
  {

      [HttpGet("/communities")]
      public ActionResult Index()
      {
          List<Community> allCommunities = Community.GetAll();
          return View(allCommunities);
      }
  }
}