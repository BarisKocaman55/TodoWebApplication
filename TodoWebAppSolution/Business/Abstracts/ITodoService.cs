using Business.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ITodoService
    {
        BusinessLayerResult<Todo> InsertTodo(int ownerId, Todo data);
        List<Todo> ListTodos(int ownerId);
        List<Todo> ListCompletedTodos(int ownerId);
        List<Todo> ListUnCompleteTodos(int ownerId);
        BusinessLayerResult<Todo> UpdateTodo(Todo todo);
        BusinessLayerResult<Todo> DeleteTodo(Todo todo);
        void ChangeStatusOfComplete(int id);
    }
}
