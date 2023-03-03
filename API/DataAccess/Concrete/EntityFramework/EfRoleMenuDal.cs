using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleMenuDal : EfEntityRepositoryBase<RoleMenu, NorthwindContext>, IRoleMenuDal
    {
        public RoleMenu AddList(List<RoleMenu> roleMenuList)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var item in roleMenuList)
                {
                    //context.RoleMenus.AddRange(item);
                    //context.SaveChanges();
                    var addedEntity = context.Entry(item);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }

            }
            return null;
        }

        public List<RoleMenuDto> GetAllRoleMenu()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from Menus in context.Menus
                              join RoleMenus in context.RoleMenus on new { MenuId = (int)Menus.MenuId } equals new { MenuId = Convert.ToInt32(RoleMenus.MenuId) }
                              join Roles in context.Roles on new { RoleId = Convert.ToInt32(RoleMenus.RoleId) } equals new { RoleId = (int)Roles.RoleId }

                              select new RoleMenuDto
                              {
                                  RoleMenuId = RoleMenus.RoleMenuId,
                                  RoleId = (int)RoleMenus.RoleId,
                                  RoleName = Roles.RoleName,
                                  MenuId = (int)RoleMenus.MenuId,
                                  MenuName = Menus.MenuName,
                                  MenuIcon = Menus.MenuIcon,
                                  MenuRouterLink = Menus.MenuRouterLink,
                                  HideMenu = (bool)Menus.HideMenu,
                                  Visualization = (bool)RoleMenus.Visualization,
                                  Liste = (bool)RoleMenus.Liste,
                                  Detail = (bool)RoleMenus.Detail,
                                  Add = (bool)RoleMenus.Add,
                                  Update = (bool)RoleMenus.Update,
                                  Delete = (bool)RoleMenus.Delete,
                                  Status = (bool)RoleMenus.Status
                              }).ToList();
                return result;
                //throw new System.NotImplementedException();
            }
        }

        public List<RoleMenuDto> GetAllByRoleId(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from Menus in context.Menus
                              join RoleMenus in context.RoleMenus on new { MenuId = (int)Menus.MenuId } equals new { MenuId = Convert.ToInt32(RoleMenus.MenuId) }
                              join Roles in context.Roles on new { RoleId = Convert.ToInt32(RoleMenus.RoleId) } equals new { RoleId = (int)Roles.RoleId }
                              where
                                  RoleMenus.RoleId == id
                              select new RoleMenuDto
                              {
                                  RoleMenuId = RoleMenus.RoleMenuId,
                                  RoleId = (int)RoleMenus.RoleId,
                                  RoleName = Roles.RoleName,
                                  MenuId = (int)RoleMenus.MenuId,
                                  MenuName = Menus.MenuName,
                                  MenuIcon = Menus.MenuIcon,
                                  MenuRouterLink = Menus.MenuRouterLink,
                                  HideMenu = (bool)Menus.HideMenu,
                                  Visualization = (bool)RoleMenus.Visualization,
                                  Liste = (bool)RoleMenus.Liste,
                                  Detail = (bool)RoleMenus.Detail,
                                  Add = (bool)RoleMenus.Add,
                                  Update = (bool)RoleMenus.Update,
                                  Delete = (bool)RoleMenus.Delete,
                                  Status = (bool)RoleMenus.Status
                              }).ToList();
                return result;
                //throw new System.NotImplementedException();
            }
        }

        public List<RoleMenu> GetAllRoleMenuByRoleId(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var RoleMenuList = context.RoleMenus.Where(x => x.RoleId == id).ToList();
                return RoleMenuList;
            }

            throw new NotImplementedException();
        }

        public RoleMenu UpdateAll(List<RoleMenu> roleMenuList)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var item in roleMenuList)
                {                    
                    var addedEntity = context.Entry(item);
                    addedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            return null;
        }
    }
}
