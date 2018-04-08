using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbMetadata.Models;
using Microsoft.EntityFrameworkCore;

namespace DbMetadata.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly MetadataContext _context;

        public TaskController(MetadataContext context)
        {
            _context = context;
        }

        // GET api/Task
        public IEnumerable<TaskDto> Get()
        {
            return _context.Tasks
                .ToList()
                .Select(t => (TaskDto)t);
        }

        // GET api/Task/5
        [HttpGet]
        public TaskDto Get(int id)
        {
            return (TaskDto)_context
                .Tasks
                .Find(id);
        }

        // PUT api/Task/5
        [HttpPut("{id}")]
        public IActionResult EditTask(int id, TaskDto taskDto)
        {
            var updatedTask = (DbMetadata.Models.Task)taskDto;
            updatedTask.TaskId = id;
            _context.Entry(updatedTask).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // POST api/Task
        [HttpPost]
        public IActionResult CreateTask(TaskDto taskDto)
        {
            var newTask = (DbMetadata.Models.Task)taskDto;

            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newTask.TaskId,
                action = "inserted"
            });
        }

        // DELETE api/Task/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return Ok(new
            {
                action = "deleted"
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}