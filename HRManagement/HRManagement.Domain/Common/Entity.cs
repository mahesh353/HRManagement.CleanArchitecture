using System;
    
namespace HRManagement.Domain.Common
{
	public abstract class Entity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
