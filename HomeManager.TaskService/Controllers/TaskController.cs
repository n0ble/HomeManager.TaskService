using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeManager.TaskService.DataLayer;
using HomeManager.TaskService.DataLayer.Dapper;
using HomeManager.TaskService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeManager.TaskService.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly TaskContext _context;
        private readonly ITaskItemRepository _repository;

        public TaskController(TaskContext context)
        {
            _context = context;

            if (!_context.TaskItems.Any())
            {
                _context.TaskItems.Add(new TaskItem { Subject = "Item1" });
                _context.SaveChanges();
            }

            _repository = new TaskItemRepository();
        }

        [HttpGet]
        public IEnumerable<TaskItem> GetAll()
        {

            return _repository.GetAll();//_context.TaskItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetById(long id)
        {
            var item = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _repository.Add(item);
            
            return CreatedAtRoute("GetTask", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TaskItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Priority = item.Priority;
            todo.Subject = item.Subject;

            _context.TaskItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
