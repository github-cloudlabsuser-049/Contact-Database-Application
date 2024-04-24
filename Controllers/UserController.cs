using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
        // Implement the details method here
        // Find the user with the specified ID in the userlist
        User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                // If the user is found, pass it to the Details view
                return View(user);
            }
            else
            {
                // If no user is found with the provided ID, return a HttpNotFoundResult
                return HttpNotFound();
            }
    
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Create a new instance of the User class
            User newUser = new User();

            // Pass the new user object to the Create view
            return View(newUser);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                // Pass the user object to the Edit view
                return View(user);
            }
            else
            {
                // If no user is found with the provided ID, return a HttpNotFoundResult
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Find the user with the specified ID in the userlist
            User existingUser = userlist.FirstOrDefault(u => u.Id == id);

            if (existingUser != null)
            {
                // Update the user's information with the new values
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            else
            {
                // If no user is found with the provided ID, return a HttpNotFoundResult
                return HttpNotFound();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user with the specified ID in the userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                // Remove the user from the userlist
                userlist.Remove(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            else
            {
                // If no user is found with the provided ID, return a HttpNotFoundResult
                return HttpNotFound();
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user with the specified ID in the userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                // Remove the user from the userlist
                userlist.Remove(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            else
            {
                // If no user is found with the provided ID, return a HttpNotFoundResult
                return HttpNotFound();
            }
        }
    }
}
