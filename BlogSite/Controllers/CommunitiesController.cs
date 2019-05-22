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
          ViewBag.Title = "Browse Communities";
          return View(allCommunities);
      }

      [HttpGet("/communities/{id}")]
      public ActionResult Show(int id)
      {
          Community thisCommunity = Community.Find(id);
          ViewBag.Title = thisCommunity.GetName();
          return View(thisCommunity);
      }
  }
}