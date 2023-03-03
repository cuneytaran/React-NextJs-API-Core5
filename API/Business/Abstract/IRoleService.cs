using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<List<Role>> GetAll();
        IDataResult<List<Role>> GetAllByRoleId(int id);
        IDataResult<List<Role>> GetRoleMenuDetails();
        IDataResult<Role> GetById(int roleId);
        IResult Add(Role role);
        IResult RoleAndRoleMenuAdd(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
        IResult DeleteRoleAndRoleMenu(Role role);
        IResult AddTransactionalTest(Role role);
    }
}
