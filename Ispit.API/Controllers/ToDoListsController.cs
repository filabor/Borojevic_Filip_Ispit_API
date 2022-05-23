using Ispit.API.Data;
using Ispit.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        public readonly ToDoContext _context;

        public ToDoListsController(ToDoContext context)
        {
            _context = context;
        }


        // GET: api/ToDoLists
        [HttpGet]
        public ActionResult GetToDoLists()
        {
            try
            {
                var lists = _context.ToDoLists.ToList();

                return Ok(lists);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // POST: api/ToDoLists
        [HttpPost]
        public ActionResult PostToDoList(ToDoList new_list)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.ToDoLists.Add(new_list);
                _context.SaveChanges();

                return Ok("Successfully created!");

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // GET: api/ToDoLists/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetToDoListById(int id)
        {
            try
            {
                var list_id = _context.ToDoLists.FirstOrDefault(l => l.Id == id);

                if (list_id == null)
                {
                    return NotFound("Result not found!");
                }

                return Ok(list_id);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to display result, an error occurred!");
            }
        }


        // PUT: api/ToDoLists/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateToDoList(int id, ToDoList update_list)
        {
            try
            {
                if (id != update_list.Id)
                {
                    return BadRequest("ID parameters do not match!");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Data is invalid!");
                }

                var find_list = _context.ToDoLists.FirstOrDefault(l => l.Id == id);

                if (find_list == null)
                {
                    return NotFound("No record found!");
                }

                var result = _context.ToDoLists.FirstOrDefault(x => x.Id == update_list.Id);
                result.Title = update_list.Title;
                result.Description = update_list.Description;
                result.IsComplited = update_list.IsComplited;
                _context.SaveChanges();

                return Ok(update_list);


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data!");
            }
        }


        // DELETE: api/ToDoLists/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteToDoList(int id)
        {
            try
            {
                var list_to_delete = _context.ToDoLists.SingleOrDefault(l => l.Id == id);

                _context.ToDoLists.Remove(list_to_delete);
                _context.SaveChanges();

                return Ok("Successfully deleted!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to delete, an error has occurred!");
            }
        }

    }
}
