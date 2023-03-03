using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRoleMenuDal : IEntityRepository<RoleMenu>
    {        
        List<RoleMenuDto> GetAllRoleMenu();
        List<RoleMenuDto> GetAllByRoleId(int id);
        List<RoleMenu> GetAllRoleMenuByRoleId(int id);
        RoleMenu AddList(List<RoleMenu> roleMenuList);
        RoleMenu UpdateAll(List<RoleMenu> roleMenuList);

    }
}
