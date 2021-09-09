using Business.Abstracts;
using Business.Results;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class TodoManager : ManagerBase<Todo>, ITodoService
    {
        private Repository<Todo> repo_todo = new Repository<Todo>();

        public BusinessLayerResult<Todo> InsertTodo(int ownerId, Todo data)
        {
            BusinessLayerResult<Todo> result = new BusinessLayerResult<Todo>();
            int db_result = repo_todo.Insert(new Todo()
            {
                Description = data.Description,
                IsDone = false,
                OwnerId = ownerId,
            });

            if(db_result > 0)
            {
                result.Result = data;
            }

            else
            {
            result.AddError(Entities.Messages.ErrorMessageCode.CouldNotAddTodo, "Todo can not added...");
            }

            return result;
        }

        public List<Todo> ListTodos(int ownerId)
        {
            return repo_todo.List(x => x.OwnerId == ownerId);
        }

        public List<Todo> ListCompletedTodos(int ownerId)
        {
            return repo_todo.List(x => x.OwnerId == ownerId && x.IsDone == true);
        }

        public List<Todo> ListUnCompleteTodos(int ownerId)
        {
            return repo_todo.List(x => x.OwnerId == ownerId && x.IsDone == false);
        }

        public BusinessLayerResult<Todo> UpdateTodo(Todo todo)
        {
            BusinessLayerResult<Todo> result = new BusinessLayerResult<Todo>();
            int db_result = repo_todo.Update(todo);

            if(db_result > 0)
            {
                result.Result = todo;
            }

            else
            {
                result.AddError(Entities.Messages.ErrorMessageCode.CouldNotUpdateTodo, "Error occured wihle updating todo...");
            }

            return result;
        }

        public BusinessLayerResult<Todo> DeleteTodo(Todo todo)
        {
            BusinessLayerResult<Todo> result = new BusinessLayerResult<Todo>();
            int db_result = repo_todo.Delete(todo);

            if(db_result > 0)
            {
                result.Result = todo;
            }

            else
            {
                result.AddError(Entities.Messages.ErrorMessageCode.CouldNotDeleteTodo, "Error Occured while deleting todo");
            }

            return result;
        }

        public void ChangeStatusOfComplete(int id)
        {
            Todo db_result = repo_todo.Find(x => x.Id == id);
            if(db_result != null)
            {
                if(db_result.IsDone == true)
                {
                    db_result.IsDone = false;
                }

                if(db_result.IsDone == false)
                {
                    db_result.IsDone = true;
                }

                repo_todo.Update(db_result);
            }
        }
    }
}
