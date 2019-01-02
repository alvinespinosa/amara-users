using System;

namespace Amara.Solutions.Models
{
    public class BaseModel : IEntity
    {
        public string Id { get ; set ; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get ; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get ; set; }
    }
}
