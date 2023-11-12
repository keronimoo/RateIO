using Microsoft.AspNetCore.Identity;
namespace RateIO.Models;

public class User : IdentityUser
{
    public int followers { get; set; }

    public int following { get; set; }

    public int photos { get; set; }

    public string profileAbout { get; set; } = "Default Profile About";

    public string ProfilePhotoPath { get; set; }
    public ICollection<UserPost> UserPosts { get; set; }

}