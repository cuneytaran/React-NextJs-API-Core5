using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, NorthwindContext>, IRoleDal
    {
        private readonly IRoleMenuDal _roleMenuDal;
        private readonly IMenuDal _menuDal;

        public EfRoleDal(IRoleMenuDal roleMenuDal, IMenuDal menuDal)
        {
            _roleMenuDal = roleMenuDal;
            _menuDal = menuDal;
        }

        public Role DeleteRoleAndRoleMenu(Role deleteRole)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(deleteRole);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

                var RoleMenuList = _roleMenuDal.GetAllRoleMenuByRoleId(deleteRole.RoleId);
                foreach (var item in RoleMenuList)
                {
                    var deletedRoleMenuEntity = context.Entry(item);
                    deletedRoleMenuEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }

            }
            return null;
        }

        public Role RoleAndRoleMenuAdd(Role role)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                Role RoleAdd = new Role();
                RoleAdd.RoleName = role.RoleName;
                RoleAdd.Status = true;
                context.Roles.Add(RoleAdd);
                context.SaveChanges();

                var MenuList = _menuDal.GetAll();
                foreach (var item in MenuList)
                {
                    RoleMenu add = new RoleMenu();
                    add.RoleId = RoleAdd.RoleId;
                    add.MenuId = item.MenuId;
                    add.Visualization = false;
                    add.Liste = false;
                    add.Detail = false;
                    add.Add = false;
                    add.Update = false;
                    add.Delete = false;
                    add.Status = true;
                    context.RoleMenus.Add(add);
                    context.SaveChanges();
                }
            }
            return null;
        }
    }
}