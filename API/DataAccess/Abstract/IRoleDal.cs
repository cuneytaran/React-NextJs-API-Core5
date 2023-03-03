using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
        Role DeleteRoleAndRoleMenu(Role deleteRole);
        Role RoleAndRoleMenuAdd(Role roleAndRoleMenu);
    }
}
