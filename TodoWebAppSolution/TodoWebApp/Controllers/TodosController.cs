using Business.Abstracts;
using Business.Concretes;
using Business.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoService _todoService;

        public TodosController(ITodoService todoService) // Dependency Injection
        {
            _todoService = todoService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAllTodos()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("login"));
            if(sessionUser != null)
            {
                int userId = sessionUser.Id;
                return Ok(new { status = 200, isSuccess = true,  message = "Successfull", data = _todoService.ListTodos(userId) });
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured !!!" });
        }

        [HttpGet("getCompletedTodos")]
        public IActionResult GetAllCompletedTodos()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("login"));
            if(sessionUser != null)
            {
                int userId = sessionUser.Id;
                return Ok(new { status = 200, isSuccess = true, message = "Successfull", data = _todoService.ListCompletedTodos(userId) });
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured !!!" });
        }
        
        [HttpGet("getUncompletedTodos")]
        public IActionResult GetAllUncompleted()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("login"));
            if (sessionUser != null)
            {
                int userId = sessionUser.Id;
                return Ok(new { status = 200, isSuccess = true, message = "Successfull", data = _todoService.ListUnCompleteTodos(userId) });
            }

            return BadRequest( new { status = 404, isSuccess = false, message = "Error Occured !!!" });
        }

        [HttpPost("addTodo")]
        public IActionResult AddTodo(Todo todo)
        {
            if (ModelState.IsValid)
            {
                var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("login"));
                int userId = sessionUser.Id;

                BusinessLayerResult<Todo> res = _todoService.InsertTodo(userId, todo);
                if(res.Errors.Count > 0)
                {
                    return Ok(new { status = 401, isSuccess = false, message = res.Errors[0] });
                }

                return Ok(new { status = 200, isSuccess = true, message = "Todo Successfully Added...", data = res.Result});
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured !!!" });
        }


        [HttpPost("updateTodo")]
        public IActionResult UpdateTodo(Todo todo)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Todo> res = _todoService.UpdateTodo(todo);
                if(res.Errors.Count > 0)
                {
                    return Ok(new { status = 401, isSuccess = false, message = res.Errors[0] });
                }

                return Ok(new { status = 200, isSuccess = true, message = "Updated Successfully..." });
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured..." });
        }

        [HttpPost("deleteTodo")]
        public IActionResult DeleteTodo(Todo todo)
        {
            BusinessLayerResult<Todo> res = _todoService.DeleteTodo(todo);
            if(res.Errors.Count > 0)
            {
                return Ok(new { status = 401, isSuccess = false, message = res.Errors[0] });
            }

            return Ok(new { status = 200, isSuccess = true, message = "Todo Deleted Successfully" });
        }

    }
}