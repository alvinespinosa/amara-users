using System;

namespace UserManagement.Models.Entities
{
    public class User : BaseModel
    {
        public User()
        {
            this.ForgotPasswordKey = string.Empty;
            this.PasswordNeverExpired = true;
            this.Password = "default";
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool PasswordNeverExpired { get; set; }
        public string ForgotPasswordKey { get; set; }
        public DateTime? LockedAt { get; set; }
    }
}
