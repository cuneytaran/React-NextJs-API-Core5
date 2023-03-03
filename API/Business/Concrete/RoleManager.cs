using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        [TransactionScopeAspect]
        public IResult Add(Role role)
        {
            IResult result = BusinessRules.Run(CheckIfRoleNameExists(role.RoleName));
            if (result != null)
            {
                return result;
            }

            role.Status = true;
            _roleDal.Add(role);

            return new SuccessResult(Messages.RoleAdded);
        }

        [TransactionScopeAspect]
        public IResult RoleAndRoleMenuAdd(Role role)
        {
            IResult result = BusinessRules.Run(CheckIfRoleNameExists(role.RoleName));
            if (result != null)
            {
                return result;
            }

            role.Status = true;
            _roleDal.RoleAndRoleMenuAdd(role);

            return new SuccessResult(Messages.RoleAdded);
        }

        public IResult AddTransactionalTest(Role role)
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect]
        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.RoleDelete);
        }

        public IResult DeleteRoleAndRoleMenu(Role role)
        {
            _roleDal.DeleteRoleAndRoleMenu(role);
            return new SuccessResult(Messages.RoleDelete);
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll(), Messages.RoleListed);
        }

        public IDataResult<List<Role>> GetAllByRoleId(int id)
        {
            var result=_roleDal.GetAll(p => p.RoleId == id);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<Role>>(result, Messages.RoleListed);
            }

            return new ErrorDataResult<List<Role>>(result, Messages.RoleError);
             
        }

        public IDataResult<Role> GetById(int roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(p => p.RoleId == roleId));
        }

        public IDataResult<List<Role>> GetRoleMenuDetails()
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect]
        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult(Messages.RoleUpdate);
        }

        private IResult CheckIfRoleNameExists(string roleName)
        {
            var result = _roleDal.GetAll(p => p.RoleName == roleName).Any();
            if (result)
            {
                return new ErrorResult(Messages.RoleNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
