using HRManagement.Domain.Common;

namespace HRManagement.Domain.Entities
{
	public class User : Entity
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
