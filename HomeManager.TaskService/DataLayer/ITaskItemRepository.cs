using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeManager.TaskService.Models;

namespace HomeManager.TaskService.DataLayer
{
    public interface ITaskItemRepository
    {
        List<TaskItem> GetAll();
        TaskItem GetById(int id);
        TaskItem Add(TaskItem taskItem);
        TaskItem Update(TaskItem taskItem);
        void Remove(int id);

        void Save(TaskItem taskItem);
    }
}
