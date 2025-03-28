using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;

namespace MyApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: User/Form
        public ActionResult Form()
        {
            return View();
        }

        // POST: User/SubmitForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Name = model.Name, Email = model.Email };
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("Form", model);
        }
    }

    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}