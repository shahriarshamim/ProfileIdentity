using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProfileIdentity.Data;
using ProfileIdentity.ViewModels;

namespace ProfileIdentity.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            return View(new UserProfile
            {
                Name = user.Name,
                ProfilePicPath = user.ProfilePicPath
            });
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            return View(new UserProfile
            {
                Name = user.Name,
                ProfilePicPath = user.ProfilePicPath
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserProfile model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();
          
            user.Name = model.Name;
          
            if (model.Pic != null)
            {
                var folder = Path.Combine(
                    _environment.WebRootPath,
                    "images"
                );

                var fileName = Guid.NewGuid() +
                               Path.GetExtension(model.Pic.FileName);

                var filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Pic.CopyToAsync(stream);
                }

                user.ProfilePicPath = "/images/" + fileName;
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }
}