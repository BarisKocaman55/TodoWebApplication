using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists,
        EmailAlreadyExists,
        UserIsNotActivate,
        CheckYourEmail,
        UsernameOrPassWrong,
        UserNotFound,
        ProfileCouldNotUpdated,
        UserCouldNotRemove,
        UserCouldNotFound,
        UserCouldNotInserted,
        UserCouldNotUpdated,
        CouldNotAddTodo,
        CouldNotUpdateTodo,
        CouldNotDeleteTodo
    }
}
