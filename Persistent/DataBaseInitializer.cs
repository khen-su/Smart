using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using Common.Settings;

namespace Persistent
{
    public class DatabaseInitializer
    {
        public DatabaseInitializer(DatabaseSettings settings)
        {
            DatabaseName = settings.FullName;
        }

        private string DatabaseName { get; }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            var createStatusTypeTableQuery = @"
                                CREATE TABLE IF NOT EXISTS dbo.StatusTypes (
                              [ID] INTEGER NOT NULL PRIMARY KEY ,
                              [Name] NCHAR(20))";

            var createTaskTableQuery = @"   CREATE TABLE IF NOT EXISTS dbo.MyTasks (
                              [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              [Status] INTEGER NOT NULL DEFAULT 1 REFERENCES StatusTypes(Id),
                              [Description] VARCHAR(255)  NULL)";

            using var con = new SQLiteConnection(
                $"datasource = {DatabaseName}");
            using var com = new SQLiteCommand(con);
            con.Open();

            com.CommandText = createStatusTypeTableQuery;
            com.ExecuteNonQuery();
            com.CommandText = createTaskTableQuery;
            com.ExecuteNonQuery();
        }

        public void Initialize()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), DatabaseName))) CreateDatabase();
        }
    }
}