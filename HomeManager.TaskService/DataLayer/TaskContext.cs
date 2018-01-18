using HomeManager.TaskService.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.TaskService.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext( DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
