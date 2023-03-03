using Core.Entities;

namespace Entities.Concrete
{
    public class RoleMenu: IEntity
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
    }
}
