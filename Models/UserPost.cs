namespace RateIO.Models
{
    public class UserPost
    {
        public int Id { get; set; }

        public string Filename { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }

        public int Rate { get; set; }

        public DateTime CreatedDate { get; set; }

        


        // Foreign key for the User model
        public string UserId { get; set; }

        // Navigation property to access the associated User
        public User User { get; set; }
    }
}
