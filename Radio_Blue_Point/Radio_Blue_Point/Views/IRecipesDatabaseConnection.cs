using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Blue_Point.Views
{
    public interface IRecipesDatabaseConnection
    {
        SQLiteConnection GetConnection();
    }
}
