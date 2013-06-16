using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using BrewHow.Models;

namespace BrewHow.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            List<Recipe> recipes = null;

            using (var context = new BrewHowContext())
            {
                recipes = (from recipe in context.Recipes
                           select recipe).ToList();
            }

            return View(recipes);
        }

    }
}
