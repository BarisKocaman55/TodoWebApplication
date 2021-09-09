using Business.Results;
using Entities.Concrete;
using Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        BusinessLayerResult<User> RegisterUser(RegisterViewModel data);
        BusinessLayerResult<User> LoginUser(LoginViewModel data);
        BusinessLayerResult<User> GetUserById(int id);
        BusinessLayerResult<User> UpdateProfile(User data);
        BusinessLayerResult<User> RemoveUserById(int id);
    }
}
