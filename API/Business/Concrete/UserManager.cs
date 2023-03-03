using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        private object userForRegisterDto;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        [TransactionScopeAspect]
        public IResult Update(UserDto user)
        {
            User userupdate = new User();
            userupdate.Email = user.Email;
            userupdate.FirstName = user.FirstName;
            userupdate.LastName = user.LastName;
            userupdate.RoleId = user.RoleId;
            userupdate.Status = user.Status;
            userupdate.UserId = user.UserId;

            var Userdetail = _userDal.GetAll(x => x.UserId == user.UserId).FirstOrDefault();


            if (user.Password==null)
            {
                userupdate.PasswordHash = Userdetail.PasswordHash;
                userupdate.PasswordSalt = Userdetail.PasswordSalt;               
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                var userpassword = new User
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                userupdate.PasswordHash = userpassword.PasswordHash;
                userupdate.PasswordSalt = userpassword.PasswordSalt;
            }

            _userDal.Update(userupdate);
            return new SuccessResult(Messages.UserUpdate);
        }

        [TransactionScopeAspect]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDelete);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == userId));
        }
    }
}
