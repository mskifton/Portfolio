namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.DataAccess;
    using Dalek_Mint.Models;
    using Dalek_Mint.Utilities;
    using PagedList;
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="ClubsController" />
    /// </summary>
    public class ClubsController : BaseController
    {
        /// <summary>
        /// Defines the db
        /// </summary>
        private MintContext db = new MintContext();

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View(db.Club.ToList());
        }

        /// <summary>
        /// The AllClubs
        /// </summary>
        /// <param name="sortOrder">The sortOrder<see cref="string"/></param>
        /// <param name="currentFilter">The currentFilter<see cref="string"/></param>
        /// <param name="searchString">The searchString<see cref="string"/></param>
        /// <param name="page">The page<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult AllClubs(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //Sets the title
            ViewBag.NavTag = "Clubs";

            // Required for stored proc, default is blank 
            string search = Request.QueryString["search"];

            if (search == null)
            {
                search = "";
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var clubs = SQLUtilities.GetAllClubs(search);
            ViewBag.SearchTerm = search;

            return View(clubs.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Admin create club form
        /// </summary>
        /// <returns>the <see cref="ActionResult"/></returns>
        public ActionResult AdminClubForm()
        {
            ViewBag.NavTag = "AdminClubForm";

            return View();
        }

        /// <summary>
        /// The Club
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Club(int id)
        {
            ViewBag.NavTag = "Clubs";

            Club club = GetClubById(id);

            return View(club);
        }

        /// <summary>
        /// The Details
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="club">The club<see cref="Club"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Club club, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                    {
                        byte[] bytes;

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }

                        club.Image = bytes;

                    }
                    else
                    {
                        ViewBag.Picture = "Invalid";
                        return View("AdminClubForm", club);
                    }
                }
                db.Club.Add(club);
                db.SaveChanges();

                SetFlash(enums.FlashMessageType.Success, "Club '" + club.Name + "' was succesfully created");

                return RedirectToAction("AllClubs");
            }

            return View("AdminClubForm", club);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Edit(int? id)
        {
            ViewBag.FormType = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View("AdminClubForm", club);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="club">The club<see cref="Club"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Club club, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();

                var DBClub = (from e in db.Club
                               where e.ClubId == club.ClubId
                               select e).FirstOrDefault();

                if (file != null && file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                    {
                        byte[] bytes;

                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }

                        DBClub.Image = bytes;

                    }
                    else
                    {
                        ViewBag.Picture = "Invalid";
                        return View("AdminFormCreation", DBClub);
                    }
                }

                // Open to suggestions on how to do this differently
                if (file == null && Session["Image"] != null)
                {
                    DBClub.Image = (byte[])Session["Image"];
                }
                Session["Image"] = null;

                db.SaveChanges();


                // Sets notification and takes to the list page. 
                SetFlash(enums.FlashMessageType.Success, "Club '" + club.Name + "' was succesfully updated");

                return RedirectToAction("AllClubs", "Clubs");
            }
            return View("AdminClubForm", club);
        }

        /// <summary>
        /// The DeleteConfirmed
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Delete(int id)
        {
            Club club = db.Club.Find(id);
            club.IsArchived = true;
            db.Entry(club).State = EntityState.Modified;
            db.SaveChanges();

            SetFlash(enums.FlashMessageType.Success, "Club '" + club.Name + "' was succesfully removed");

            return RedirectToAction("AllClubs");
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The GetClubById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Club"/></returns>
        private Club GetClubById(int id)
        {
            string Procedure = "Club By ID";
            Club club = new Club();

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@ClubID", id);


            // Uses connection from DB and pulls and builds out the club
            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    club.ClubId = (int)reader["ClubId"];
                    club.Name = reader["Name"].ToString();
                    club.Description = reader["Description"].ToString();
                    club.Events = GetUpcomingEvents(id);
                    club.Contact = reader["Contact"].ToString();
                    try
                    {
                        club.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        club.Image = null;
                    }
                }

                Connection.Close();
            }

            return club;
        }

        /// <summary>
        /// Gets the upcoming events for the club.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>Returns the list of events</returns>
        private ObservableCollection<Event> GetUpcomingEvents(int id)
        {
            ObservableCollection<Event> Events = new ObservableCollection<Event>();

            string Procedure = "Upcoming Club Events";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@ClubID", id);

            // Uses connection from DB and pulls and builds out the clubs
            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Event evnt = new Event();

                    evnt.EventId = (int)reader["EventId"];
                    evnt.Name = reader["Name"].ToString();
                    evnt.Description = reader["Description"].ToString();
                    evnt.Date = Convert.ToDateTime(reader["Date"]);
                    evnt.Address = reader["Address"].ToString();
                    evnt.CategoryName = reader["CategoryName"].ToString();
                    try
                    {
                        evnt.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        evnt.Image = null;
                    }

                    Events.Add(evnt);
                }

                Connection.Close();
            }

            return Events;
        }

        /// <summary>
        /// The GetOfficers
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ObservableCollection{User}"/></returns>
        private ObservableCollection<User> GetOfficers(int id)
        {
            ObservableCollection<User> Officers = new ObservableCollection<User>();

            string Procedure = "Club Officers";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@ClubID", id);


            // Uses connection from DB and pulls and builds out the officers
            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Title = reader["Title"].ToString();

                    Officers.Add(user);
                }

                Connection.Close();
            }

            return Officers;
        }
    }
}
