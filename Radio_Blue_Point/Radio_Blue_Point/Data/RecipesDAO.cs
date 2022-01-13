using Radio_Blue_Point.Models;
using Radio_Blue_Point.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Radio_Blue_Point.Data
{
    public class RecipesDAO
    {

		public int SaveRecipe(RecipeModel recipe)
		{
			lock (collisionLock)
			{
				if (recipe.Id != 0)
				{
					database.Update(recipe);
					return recipe.Id;
				}
				else
				{
					return database.Insert(recipe);
				}
			}
		}

		public int DeleteRecipe(int id)
		{
			lock (collisionLock)
			{
				return database.Delete<RecipeModel>(id);
			}
		}

		public RecipeModel GetRecipe(String nome)
		{
			lock (collisionLock)
			{
				return database.Table<RecipeModel>().FirstOrDefault(x => x.Nome == nome);
			}
		}


		public RecipesDAO()
        {
            database = DependencyService.Get<IRecipesDatabaseConnection>().GetConnection();

            database.CreateTable<RecipeModel>();
        }
        private SQLiteConnection database;

        private static object collisionLock = new object();
    }


}
