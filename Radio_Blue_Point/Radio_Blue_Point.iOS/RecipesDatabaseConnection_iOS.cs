using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;


using Xamarin.Forms;
using Radio_Blue_Point.iOS;
using SQLite;
using System.IO;
using Radio_Blue_Point.Views;

[assembly: Dependency(typeof(RecipesDatabaseConnection_iOS))]

namespace Radio_Blue_Point.iOS
{
    public class RecipesDatabaseConnection_iOS : IRecipesDatabaseConnection
    {

        public RecipesDatabaseConnection_iOS() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Login.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
