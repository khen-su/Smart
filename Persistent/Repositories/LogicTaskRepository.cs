using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Persistent.Repositories.Interfaces;

namespace Persistent.Repositories
{
    public class LogicTaskRepository : BaseRepository, IReadOnlyTaskRepository, IWriteTaskRepository
    {
        public LogicTaskRepository(string connectionString) : base(connectionString)
        {
        }

        private readonly string GetList_Query = @"SELECT Id, StatusType 
                                                  FROM dbo.Tasks";

        private readonly string Select_Query = @"SELECT Id, StatusType 
                                                  FROM dbo.Tasks WHERE Id = @Id";

        private readonly string Insert_Query = @"INSERT INTO dbo.Tasks ( Description, StatusType) 
                                                    VALUES(@Description, 1)";

        private readonly string Delete_Query = @"DELETE FROM dbo.Tasks WHERE Id = @Id";

        private readonly string Update_Query = @"UPDATE dbo.Tasks SET Description = @Description 
                                                    WHERE dbo.Tasks.Id = @Id";

        public void DefaultMapper(IDataReader reader, LogicTask entity)
        {
            entity.Id = (int) reader["Id"];
            entity.Description = reader["Descrition"].ToString();
        }
        
        public async Task<List<LogicTask>> GetList()
        {
            await using var con = new SqlConnection(_connectionString);
            await using var com = new SqlCommand(GetList_Query, con);

            SqlDataReader reader = await com.ExecuteReaderAsync();

            var logicTasks = new List<LogicTask>();
            while (reader.Read())
            {
                var logicTask = new LogicTask();
                DefaultMapper(reader, logicTask);
                logicTasks.Add(logicTask);
            }
            return logicTasks;
        }
        

        public async Task<LogicTask> Get(int id)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var com = new SqlCommand(Select_Query, con);
            var idParameter = new SqlParameter("@Id", SqlDbType.Int, sizeof(int)).Value = id as object;
            com.Parameters.Add(idParameter);
            var reader = await com.ExecuteReaderAsync();

            var logicTask = new LogicTask();
            DefaultMapper(reader, logicTask);
            return logicTask;
        }

        public async Task<bool> Insert(string description)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var com = new SqlCommand(Insert_Query, con);
            var descriptionParameter = new SqlParameter("@Description", SqlDbType.VarChar).Value = description as object;
            com.Parameters.Add(descriptionParameter);
            var insertedRecords = await com.ExecuteNonQueryAsync();
            return (insertedRecords > 0);
        }

        public async Task<bool> Update(int id, string description)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var com = new SqlCommand(Update_Query);
            var idParameter = new SqlParameter("@Id", SqlDbType.Int, sizeof(int)).Value = id as object;
            var descriptionParameter = new SqlParameter("@Id", SqlDbType.VarChar).Value = description as object;

            com.Parameters.AddRange(new[] {idParameter, descriptionParameter});
            var updatedRecords = await com.ExecuteNonQueryAsync();
            return (updatedRecords > 0);
        }


        public async Task<bool> Delete(int id)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var com = new SqlCommand(Delete_Query, con);
            var idParameter = new SqlParameter("@Id", SqlDbType.Int, sizeof(int)).Value as object;
            com.Parameters.Add(idParameter);
            var deletedRecords = await com.ExecuteNonQueryAsync();
            return (deletedRecords > 0);
        }
    }
}