using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RoleMenuManager:IRoleMenuService
    {
        private readonly IRoleMenuDal _roleMenuDal;
        public RoleMenuManager(IRoleMenuDal roleMenuDal)
        {
            _roleMenuDal = roleMenuDal;
        }

        public IResult Add(RoleMenu roleMenu)
        {
            throw new NotImplementedException();
        }

        public IResult AddList(List<RoleMenu> roleMenuList)
        {
            var result = _roleMenuDal.AddList(roleMenuList);
        
                return new SuccessDataResult<RoleMenu>(result, Messages.RoleMenuListed);
            
        }

        public IResult AddTransactionalTest(RoleMenu roleMenu)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(RoleMenu roleMenu)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RoleMenu>> GetAll()
        {
            var result = _roleMenuDal.GetAll();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<RoleMenu>>(result, Messages.RoleMenuListed);
            }
            return new ErrorDataResult<List<RoleMenu>>(result, Messages.RoleMenuError);
        }

        public IDataResult<List<RoleMenuDto>> GetAllRoleMenu()
        {
            var result = _roleMenuDal.GetAllRoleMenu();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<RoleMenuDto>>(result, Messages.RoleMenuListed);
            }

            return new ErrorDataResult<List<RoleMenuDto>>(null, Messages.RoleMenuError);
        }


        public IDataResult<List<RoleMenuDto>> GetAllByRoleId(int id)
        {
            var result = _roleMenuDal.GetAllByRoleId(id);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<RoleMenuDto>>(result, Messages.RoleMenuListed);
            }

            return new ErrorDataResult<List<RoleMenuDto>>(null, Messages.RoleMenuError);
        }

        public IDataResult<RoleMenu> GetById(int roleMenuId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RoleMenu>> GetRoleMenuDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(RoleMenu roleMenu)
        {
            throw new NotImplementedException();
        }
        [TransactionScopeAspect]
        public IResult UpdateAll(List<RoleMenu> roleMenuList)
        {
            var result = _roleMenuDal.UpdateAll(roleMenuList);

            return new SuccessDataResult<RoleMenu>(result, Messages.RoleMenuUpdate);
        }
    }
}
