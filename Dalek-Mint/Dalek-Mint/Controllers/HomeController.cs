namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.DataAccess;
    using Dalek_Mint.Models;
    using Dalek_Mint.Utilities;
    using Dalek_Mint.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="HomeController" />
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            ViewBag.NavTag = "Home";

            HomePageViewModel HPVM = CreateHomePage();

            return View(HPVM);
        }

        public ActionResult HelpPage()
        {
            ViewBag.NavTag = "Help";

            return View();
        }

        /// <summary>
        /// Creates the pending events nav item.
        /// </summary>
        /// <returns></returns>
        public ActionResult PendingEventsNav()
        {
            var EventCount = (from e in db.Event
                              where e.IsApproved == false &&
                              e.IsArchived == false &&
                              e.Date >= DateTime.Now &&
                              e.Category != 0
                              select e).Count();

            ViewBag.PendingEventAmt = EventCount;

            return PartialView("PendingEventsNav");
        }

        /// <summary>
        /// Creates the pending news nav item.
        /// </summary>
        /// <returns></returns>
        public ActionResult PendingNewsNav()
        {
            var NewsCount = (from e in db.News
                              where e.IsApproved == false &&
                              e.IsArchived == false
                              select e).Count();

            ViewBag.PendingNewsAmt = NewsCount;

            return PartialView("PendingNewsNav");
        }

        /// <summary>
        /// Defines the db
        /// </summary>
        private MintContext db = new MintContext();

        /// <summary>
        /// The SignIn
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult SignIn()
        {
            ViewData["Message"] = "Enter your information below to sign in";

            return View();
        }

        /// <summary>
        /// The Wizard to submit forms
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Wizard()
        {
            if (Session["Admin"] == null)
            {
                ViewData["Message"] = "Select what you would like to submit...";
            }
            else
            {
                ViewData["Message"] = "Select what you would like to create...";
            }
            

            return View();
        }

        /// <summary>
        /// Allows a user to sign in to the site.
        /// </summary>
        /// <param name="user">The user that is attempting to sign in.</param>
        /// <returns>Returns either the welcome page while logged in or an error message if login credentials were not found</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            bool success = false;
            string redirect = "SignIn";

            // Find user in the database.
            foreach (User u in db.User)
            {
                // Check if username and password exists in database.
                if (u.Email == user.Email && Encryption.CheckPassword(user.Email, user.Password) == true)
                {
                    user = u;
                    success = true;
                    break;
                }
            }

            // If user was found...
            if (success == true)
            {
                // Check if the user is a an admin.
                CheckAdministrationRights(user.UserGroupId);
                redirect = "Index";

                HomePageViewModel HPVM = CreateHomePage();

                return View(redirect, HPVM);

            }
            else
            {
                ModelState.AddModelError("Email", "You have entered an invalid username or password");
            }

            return View(redirect);
        }

        /// <summary>
        /// The CreateHomePage
        /// </summary>
        /// <returns>The <see cref="HomePageViewModel"/></returns>
        public static HomePageViewModel CreateHomePage()
        {
            HomePageViewModel HPModel = new HomePageViewModel();

            List<Club> clubs = SQLUtilities.GetAllClubs(String.Empty).ToList();
            HPModel.Clubs = new ObservableCollection<Club>(clubs.Take(4));

            List<News> news = SQLUtilities.GetAllNews(String.Empty).ToList();
            HPModel.News = new ObservableCollection<News>(news.Take(5));

            List<Event> events = SQLUtilities.GetAllEvents(String.Empty).ToList();
            HPModel.UpcomingEvents = new ObservableCollection<Event>(events.Take(4));

            return HPModel;
        }

        /// <summary>
        /// Removes set sessions and allows the user to logout of the site.
        /// </summary>
        /// <returns>Returns to the sign in page to allow someone to login again.</returns>
        public ActionResult SignOut()
        {
            Session.RemoveAll();
            return View("SignIn");
        }

        /// <summary>
        /// Checks if the logged in user is an administrator.
        /// </summary>
        /// <param name="u">The user that was logged in.</param>
        private void CheckAdministrationRights(int u)
        {
            if (u == 1)
            {
                Session["Admin"] = "Admin";
            }
        }
    }
}
