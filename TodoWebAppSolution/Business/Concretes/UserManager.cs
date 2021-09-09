using Business.Abstracts;
using Business.Results;
using Common.Helpers;
using Entities.Concrete;
using Entities.Messages;
using Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : ManagerBase<User>, IUserService
    {
        public BusinessLayerResult<User> RegisterUser(RegisterViewModel data)
        {
            User user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Username already exists...");
                }

                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Email already exists...");
                }
            }
            else
            {
                int dbResult = base.Insert(new User()
                {
                    Username = data.Username,
                    Email = data.Email,                  
                    Password = data.Password,
                    IsActive = true, // Normally I want to make isActive true by email 
                });

                if (dbResult > 0)
                {
                    res.Result = Find(x => x.Email == data.Email && x.Username == data.Username);
                }
            }

            return res;
        }

        public BusinessLayerResult<User> LoginUser(LoginViewModel data)
        {
            User user = Find(x => x.Username == data.Username && x.Password == data.Password);
            BusinessLayerResult<User> layerResult = new BusinessLayerResult<User>();

            layerResult.Result = user;

            if (user != null)
            {
                if (!user.IsActive)
                {
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.UserIsNotActivate, "User is not Activated !!!");
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.CheckYourEmail, "Please check your email...");
                }
            }

            else
            {
                layerResult.AddError(Entities.Messages.ErrorMessageCode.UsernameOrPassWrong, "Username or Password is not valid !!!");
            }

            return layerResult;
        }


        public BusinessLayerResult<User> GetUserById(int id)
        {
            BusinessLayerResult<User> result = new BusinessLayerResult<User>();
            result.Result = Find(x => x.Id == id);

            if (result.Result == null)
            {
                result.AddError(Entities.Messages.ErrorMessageCode.UserNotFound, "User Not Found");
            }

            return result;
        }

        public BusinessLayerResult<User> UpdateProfile(User data)
        {
            User db_user = Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
            BusinessLayerResult<User> result = new BusinessLayerResult<User>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Username == data.Username)
                {
                    result.AddError(Entities.Messages.ErrorMessageCode.UsernameAlreadyExists, "Username already exists !!!");
                }

                if (db_user.Email == data.Email)
                {
                    result.AddError(Entities.Messages.ErrorMessageCode.EmailAlreadyExists, "Email alredy exists !!!");
                }

                return result;
            }

            result.Result = Find(x => x.Id == data.Id);
            result.Result.Email = data.Email;
            result.Result.Name = data.Name;
            result.Result.Surname = data.Surname;
            result.Result.Password = data.Password;
            result.Result.Username = data.Username;

            if (base.Update(result.Result) == 0)
            {
                result.AddError(Entities.Messages.ErrorMessageCode.ProfileCouldNotUpdated, "Error while updating profile !!!");
            }

            return result;
        }


        public BusinessLayerResult<User> RemoveUserById(int id)
        {
            User db_user = Find(x => x.Id == id);
            BusinessLayerResult<User> result = new BusinessLayerResult<User>();

            if (db_user != null)
            {
                if (Delete(db_user) == 0)
                {
                    result.AddError(Entities.Messages.ErrorMessageCode.UserCouldNotRemove, "User can not deleted !!!");
                    return result;
                }
            }

            else
            {
                result.AddError(Entities.Messages.ErrorMessageCode.UserCouldNotFound, "User can not found !!!");
            }

            return result;
        }


        public new BusinessLayerResult<User> Insert(User data)
        {
            User user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> layerResult = new BusinessLayerResult<User>();

            layerResult.Result = data;

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.UsernameAlreadyExists, "Username already exists !!!");
                }

                if (user.Email == data.Email)
                {
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.EmailAlreadyExists, "Email already exists !!!");
                }
                //throw new Exception("Username or Email is already used!!!");
            }

            else
            {
                if (base.Insert(layerResult.Result) == 0)
                {
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.UserCouldNotInserted, "User can not inserted...");
                }
            }

            return layerResult;
        }


        public new BusinessLayerResult<User> Update(User data)
        {
            User db_user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = data;

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Username already exists...");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Email already exists...");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.Username = data.Username;
            res.Result.IsActive = data.IsActive;

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kullanıcı güncellenemedi.");
            }

            return res;
        }
    }
}
