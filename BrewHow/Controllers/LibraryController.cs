using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewHow.Domain.Entities;
using BrewHow.Domain.Repositories;
using BrewHow.ViewModels;
using BrewHow.ViewModels.Mappers;
using WebMatrix.WebData;

namespace BrewHow.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserProfileEntityFactory _userProfileEntityFactory;
        private readonly IRecipeDisplayViewModelMapper _displayModelMapper;

        public LibraryController(IRecipeRepository recipeRepository,
            IUserProfileEntityFactory userProfileEntityFactory,
            IRecipeDisplayViewModelMapper displayModelMapper)
        {
            this._recipeRepository = recipeRepository;
            this._userProfileEntityFactory = userProfileEntityFactory;
            this._displayModelMapper = displayModelMapper;
        }

        public ActionResult Index(int page = 0)
        {
            var recipesInLibrary = this
                ._recipeRepository
                .GetRecipesInLibrary(WebSecurity.CurrentUserId);

            var viewModel = new PagedResult<RecipeEntity, RecipeDisplayViewModel>(
                recipesInLibrary,
                page,
                this._displayModelMapper.EntityToViewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(int id)
        {
            this._recipeRepository.AddRecipeToLibrary(
                id, WebSecurity.CurrentUserId);

            return Json(new { result = "ok" });
        }

    }
}
