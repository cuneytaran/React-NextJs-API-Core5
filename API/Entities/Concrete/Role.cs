using Core.Entities;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
    }
}
