using Core.Entities;

namespace Entities.Concrete
{
    public class OperationClaim2:IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
