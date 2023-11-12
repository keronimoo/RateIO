using Microsoft.AspNetCore.Mvc;
using RateIO.Models;
using RateIO.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RateIO.Controllers
{
    public class UserPostController : Controller
    {


        private readonly ApplicationDbContext _context;

        public UserPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(UserPost model, IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                // Get the User ID of the currently authenticated user
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Make sure the user is authenticated

                if (!string.IsNullOrEmpty(userId))
                {
                    // Create a user-specific directory if it doesn't exist
                    var userDirectory = Path.Combine("C:\\Users\\kerem\\Desktop\\RateIO\\Images", userId);

                    if (!Directory.Exists(userDirectory))
                    {
                        Directory.CreateDirectory(userDirectory);
                    }

                    // Save the file to the user's directory
                    var filePath = Path.Combine(userDirectory, uploadedFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        uploadedFile.CopyTo(stream);
                    }

                    // Create a new UserPost entity with the file details and set the UserId
                    var uploadedUserPost = new UserPost
                    {
                        Filename = uploadedFile.FileName,
                        FilePath = filePath,
                        Title = model.Title,
                        Rate = model.Rate,
                        CreatedDate = DateTime.Now,
                        UserId = userId
                    };

                    _context.UserPosts.Add(uploadedUserPost);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }


    }
}