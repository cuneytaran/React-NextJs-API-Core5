using Core.Entities;

namespace Entities.Concrete
{
    public class Menu:IEntity
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public string MenuRouterLink { get; set; }
        public bool HideMenu { get; set; }
        public bool Status { get; set; }
    }
}
