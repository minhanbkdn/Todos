using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Todos.Database.Schema;
using Todos.Models;

namespace Todos.Controllers
{
    /// <summary>
    /// Class chứa các điều hướng liên quan đến todos
    /// Author       :   AnTM - 14/11/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Todos
    /// Copyright    :   Team Todos
    /// Version      :   1.0.0
    /// </remarks>
    public class TodosController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <returns>Chuỗi Json chứa danh sách todo</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: api/todos
        /// </remarks>
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Todo> todos = new TodosModel().GetTodos();
                if (todos.Count == 0)
                {
                    return NotFound();
                }
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy todo theo id
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <returns>Chuỗi Json chứa todo lấy được</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: api/todos/{id}
        /// </remarks>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Todo todo = new TodosModel().GetTodoById(id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Thêm mới một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>Kết quả của việc thêm mới</returns>
        /// /// <remarks>
        /// Method: POST
        /// RouterName: api/todos
        /// </remarks>
        [HttpPost]
        public IHttpActionResult Post(Todo todo)
        {
            try
            {
                new TodosModel().AddNewTodo(todo);
                return Ok(todo);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>Kết quả của việc update</returns>
        /// /// <remarks>
        /// Method: PUT
        /// RouterName: api/todos
        /// </remarks>
        [HttpPut]
        public IHttpActionResult Put(Todo todo)
        {
            try
            {
                if (new TodosModel().UpdateTodo(todo))
                {
                    return Ok(todo);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>Kết quả của việc update</returns>
        /// /// <remarks>
        /// Method: PUT
        /// RouterName: api/todos
        /// </remarks>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (new TodosModel().DeleteTodo(id))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}