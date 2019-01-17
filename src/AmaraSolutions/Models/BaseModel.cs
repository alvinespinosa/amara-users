﻿using System;

namespace Amara.Solutions.Models
{
    public abstract class BaseModel : IEntity
    {
        public Guid Id { get ; set ; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get ; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get ; set; }
        public bool IsActive { get; set; }
    }
}
