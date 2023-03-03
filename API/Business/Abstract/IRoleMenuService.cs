using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRoleMenuService
    {

        IDataResult<List<RoleMenu>> GetAll();
        IDataResult<List<RoleMenuDto>> GetAllRoleMenu();
        IDataResult<List<RoleMenuDto>> GetAllByRoleId(int id);
        IDataResult<List<RoleMenu>> GetRoleMenuDetails();
        IDataResult<RoleMenu> GetById(int roleMenuId);
        IResult Add(RoleMenu roleMenu);
        IResult AddList(List<RoleMenu> roleMenuList);
        IResult Update(RoleMenu roleMenu);
        IResult UpdateAll(List<RoleMenu> roleMenuList);
        IResult Delete(RoleMenu roleMenu);
        IResult AddTransactionalTest(RoleMenu roleMenu);
    }
}
