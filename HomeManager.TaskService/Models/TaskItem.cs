using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.TaskService.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public string Asignee { get; set; }

    }
}
