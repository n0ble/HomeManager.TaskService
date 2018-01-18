using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HomeManager.TaskService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Npgsql;
using Dapper;

namespace HomeManager.TaskService.DataLayer.Dapper
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly string _connectionString;
        private IDbConnection _db;
        public TaskItemRepository()
        {
            _connectionString =
                "Server=localhost;Port=5432;Database=home_manager_tasks;User Id=postgres;Password=$Pelev1n;";//configuration.GetConnectionString("DefaultConnection");
            _db = new NpgsqlConnection(_connectionString);
        }
         
        public List<TaskItem> GetAll()
        {
            var result = _db.Query<TaskItem>("select * from tasks").ToList();
            return result;
        }

        public TaskItem GetById(int id)
        {
            return _db.Query<TaskItem>("select from tasks where id=@id", new {id}).SingleOrDefault();
        }

        public TaskItem Add(TaskItem taskItem)
        {
            var sql =
                "insert into tasks (subject, description, priority, severity,asignee) values ( @Subject, @Description, @Priority, @Severity, @Asignee);";
                _db.Query(sql, taskItem);
            return taskItem;
        }


        public TaskItem Update(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
