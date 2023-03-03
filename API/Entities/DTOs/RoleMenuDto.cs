using Core.Entities;

namespace Entities.DTOs
{
    public class RoleMenuDto : IDto
    {
        public int RoleMenuId { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool Visualization { get; set; }
        public bool Liste { get; set; }
        public bool Detail { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Status { get; set; }
        public string RoleName { get; set; }
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public string MenuRouterLink { get; set; }
        public bool HideMenu { get; set; }


    }
}
