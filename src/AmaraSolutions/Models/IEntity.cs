using System;

namespace Amara.Solutions.Models
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime ModifiedAt { get; set; }
        string ModifiedBy { get; set; }
    }
}
