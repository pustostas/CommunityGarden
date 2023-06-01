namespace CommunityGarden.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string BirthDate { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public int? ExperdID { get; set; }

        public int Role { get; set; } // 0 - user (owner or casual user), 1 - admins;
        public string PasswordHash { get; set; }  
    }
}
