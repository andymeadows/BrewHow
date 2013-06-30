using System;
using System.Linq;

using BrewHow.Domain.Entities;

namespace BrewHow.Domain.Repositories
{
    public interface IRecipeRepository
    {
        void AddRecipeToLibrary(int recipeId, int userId);
        RecipeEntity GetRecipe(int recipeId);
        IQueryable<RecipeEntity> GetRecipes();
        IQueryable<RecipeEntity> GetRecipesByStyleSlug(string styleSlug);
        IQueryable<RecipeEntity> GetRecipesInLibrary(int userId);
        void RemoveRecipeFromLibrary(int recipeId, int userId);
        void Save(RecipeEntity recipeEntity);
    }
}
