using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Radio_Blue_Point.Droid;
using Radio_Blue_Point.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(RecipesDatabaseConnection_Android))]

namespace Radio_Blue_Point.Droid
{
	public class RecipesDatabaseConnection_Android : IRecipesDatabaseConnection
	{
		public RecipesDatabaseConnection_Android() { }
		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "Login.db3";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, sqliteFilename);
			var conn = new SQLite.SQLiteConnection(path);
			return conn;
		}
	}
}