using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todos.Database.Schema;
using Z.EntityFramework.Plus;

namespace Todos.Models
{
    /// <summary>
    /// Class chứa các thao tác với database liên quan đến các todo
    /// Author       :   AnTM - 14/11/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Todos
    /// Copyright    :   Team Todos
    /// Version      :   1.0.0
    /// </remarks>
    public class TodosModel
    {
        private readonly DataContext _context;

        public TodosModel()
        {
            _context = new DataContext();
        }

        /// <summary>
        /// Lấy danh sách tất cả các todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <returns>danh sách tất cả các todo</returns>
        public List<Todo> GetTodos()
        {
            try
            {
                return _context.Todos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy todo theo id
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="id">id todo</param>
        /// <returns>todo</returns>
        public Todo GetTodoById(int id)
        {
            try
            {
                return _context.Todos.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm mới một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="todo">Todo cần thêm</param>
        /// <returns>
        /// Kết quả thêm mới
        /// Thành công : true
        /// Thất bại: false
        /// </returns>
        public bool AddNewTodo(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Update một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="todo">Todo cần update</param>
        /// <returns>
        /// Kết quả update mới
        /// Thành công : true
        /// Thất bại: false
        /// </returns>
        public bool UpdateTodo(Todo todoIn)
        {
            try
            {
                Todo todo = _context.Todos.FirstOrDefault(x => x.Id == todoIn.Id);
                if (todo == null)
                {
                    return false;
                }
                todo.IsComplete = todoIn.IsComplete;
                todo.Description = todoIn.Description;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Xóa một todo
        /// Author: AnTM - 14/11/2018 - create
        /// </summary>
        /// <param name="id">id của Todo cần xóaram>
        /// <returns>
        /// Kết quả xóa
        /// Thành công : true
        /// Thất bại: false
        /// </returns>
        public bool DeleteTodo(int id)
        {
            try
            {
                Todo todo = _context.Todos.FirstOrDefault(x => x.Id == id);
                if (todo == null)
                {
                    return false;
                }
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}