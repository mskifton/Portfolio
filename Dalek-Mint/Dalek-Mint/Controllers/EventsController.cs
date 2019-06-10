namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.DataAccess;
    using Dalek_Mint.Models;
    using Dalek_Mint.Utilities;
    using Dalek_Mint.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
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
    using System.Web.Services;

    /// <summary>
    /// Defines the <see cref="EventsController" />
    /// </summary>
    public class EventsController : BaseController
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
            return View(db.Event.ToList());
        }

        /// <summary>
        /// Approves the event and then goes to the all events view
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns></returns>
        public ActionResult Approve(int id)
        {
            ApproveEvent(id);

            var Event = (from e in db.Event
                         where e.EventId == id
                         select e).FirstOrDefault();

            SetFlash(enums.FlashMessageType.Success, "Event '" + Event.Name + "' was succesfully Approved");

            return RedirectToAction("AllEvents");
        }

        /// <summary>
        /// Approves the event with the passed in eventid
        /// </summary>
        /// <param name="eventid"></param>
        private void ApproveEvent(int eventid)
        {
            var Event = (from e in db.Event
                         where e.EventId == eventid
                         select e).FirstOrDefault();

            if (Event.EventId != 0)
            {
                Event.IsApproved = true;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Denys the event and then goes to the all events view
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns></returns>
        public ActionResult Deny(int id)
        {
            DenyEvent(id);

            return RedirectToAction("PendingEvents");
        }

        /// <summary>
        /// Approves the event with the passed in eventid
        /// </summary>
        /// <param name="eventid"></param>
        private void DenyEvent(int eventid)
        {
            var Event = (from e in db.Event
                         where e.EventId == eventid
                         select e).FirstOrDefault();

            TempData["Deny"] = Event.Name;

            if (Event.EventId != 0)
            {
                Event.IsApproved = false;
                Event.IsArchived = true;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// The AdminFormCreation
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminFormCreation()
        {
            ViewBag.NavTag = "AdminFormCreation";

            PopulateSelectionLists();

            return View();
        }

        /// <summary>
        /// The AllEvents
        /// </summary>
        /// <param name="sortOrder">The sortOrder<see cref="string"/></param>
        /// <param name="currentFilter">The currentFilter<see cref="string"/></param>
        /// <param name="searchString">The searchString<see cref="string"/></param>
        /// <param name="page">The page<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult AllEvents(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NavTag = "Events";

            // Gets the categories for the filters
            MintContext db = new MintContext();

            ViewData["Categories"] = SQLUtilities.GetCategories();

            // Searching
            string search = null;
            if (Request.QueryString["search"] != null)
            {
                search = Request.QueryString["search"];
            }

            // Categories
            int? Category = null;
            if (Request.QueryString["category"] == "0")
            {
                Category = null;
            }
            else if (Request.QueryString["category"] != null)
            {
                Category = Convert.ToInt32(Request.QueryString["category"]);
            }

            //Free Stuff/Food
            bool? FreeFood = null;
            bool? FreeStuff = null;
            if (Request.QueryString["freefood"] != null)
            {
                FreeFood = true;
            }
            if (Request.QueryString["freestuff"] != null)
            {
                FreeStuff = true;
            }

            // Date
            string Date = null;
            if (Request.QueryString["Date"] != null)
            {
                Date = Request.QueryString["Date"].ToString();
            }
            bool? Weekend = null;
            if (Request.QueryString["Weekend"] != null)
            {
                Weekend = true;
            }

            // Paging info
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);

            // Gets all the events for the page
            var events = SQLUtilities.GetAllEvents(search, Category, FreeFood, FreeStuff, Date, Weekend);

            //Sets the viewbag info
            ViewBag.SearchTerm = search;
            ViewBag.Category = Category;
            ViewBag.Date = Date;
            ViewBag.FreeStuff = FreeStuff == null ? "" : "checked";
            ViewBag.FreeFood = FreeFood == null ? "" : "checked";
            ViewBag.Weekend = Weekend == null ? "" : "checked";

            // Returns the view
            return View(events.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// The GetDataFromServer
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetDataFromServer()
        {
            int counter = 0;

            DataSet ds = new DataSet();

            List<Event> events = SQLUtilities.GetAllEvents();

            ds = SQLUtilities.ToDataSet(events);


            // After pulling the events its builds it out into a table 
            string resp = string.Empty;
            for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
            {
                string strComment = string.Empty;
                if (ds.Tables != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count >= i - 1)
                            {
                                if (ds.Tables[0].Rows[i - 1][0] != DBNull.Value)
                                {
                                    strComment = ds.Tables[0].Rows[i - 1][0].ToString();
                                }
                            }
                        }
                    }
                }
            }
            return resp;
        }

        /// <summary>
        /// The Event
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Event(int id)
        {
            ViewBag.NavTag = "Events";

            EventViewModel ToShow = new EventViewModel();

            ToShow.MainEvent = GetEventById(id);

            // If there are other events from the host...
            if (ToShow.MainEvent.EventHosts.Count > 0)
            {
                List<Event> evnts = this.GetSimilarEvents(ToShow.MainEvent.ClubHostId).ToList();

                evnts.RemoveAll(e => e.EventId == id);

                ToShow.SimilarEvents = new ObservableCollection<Event>(evnts);
            }

            //Pulls the attendance records...
            ToShow.MainEvent.Attending = GetAttending(id);
            ToShow.MainEvent.Interested = GetInterested(id);


            //Gets the campus
            ViewBag.Campus = GetCampus(ToShow.MainEvent.CampusHostId);

            ViewBag.NavTag = "Events";
            return View(ToShow);
        }

        /// <summary>
        /// Returns the campus name as a string
        /// </summary>
        /// <param name="campusHostId"></param>
        /// <returns></returns>
        public string GetCampus(int campusHostId)
        {
            string Campus = String.Empty;

            switch (campusHostId)
            {
                case 1:
                    Campus = "Stevens Point Campus";
                    break;

                case 2:
                    Campus = "Wisconsin Rapids Campus";
                    break;

                case 3:
                    Campus = "Marshfield Campus";
                    break;

                case 4:
                    Campus = "Adams Campus";
                    break;

                default:
                    Campus = "Off Campus";
                    break;
            }

            return Campus;
        }

        /// <summary>
        /// The GetAttending
        /// </summary>
        /// <param name="EventId">The EventId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int GetAttending(int EventId)
        {
            try
            {
                int attending = attending = 0;

                var whosGoing = from ea in db.EventAttendance
                                where ea.EventId == EventId
                                where ea.IsAttending == 2
                                select ea;

                return attending = whosGoing.Count();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// The GetInterested
        /// </summary>
        /// <param name="EventId">The EventId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int GetInterested(int EventId)
        {
            try
            {
                int interested = 0;

                var whosInterested = from ea in db.EventAttendance
                                     where ea.EventId == EventId
                                     where ea.IsAttending == 1
                                     select ea;

                return interested = whosInterested.Count();
            }
            catch
            {
                return 0;
            }
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
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Create()
        {
            ViewBag.NavTag = "AdminFormCreation";

            PopulateSelectionLists();

            return View();
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="@event">The event<see cref="Event"/></param>
        /// <param name="file">The file<see cref="HttpPostedFileBase"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event, HttpPostedFileBase file)
        {

            @event.Date = @event.FullDate;
            string message = "submitted";

            if (ModelState.IsValid)
            {
                if (Session["Admin"] != null)
                {
                    @event.IsApproved = true;
                    message = "created";
                }

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

                        @event.Image = bytes;

                    }
                    else
                    {
                        ViewBag.Picture = "Invalid";
                        return View("AdminFormCreation", @event);
                    }
                }
                db.Event.Add(@event);
                db.SaveChanges();

                // Sends you to the list of events and shows notifications if it worked.
                SetFlash(enums.FlashMessageType.Success, "Event '" + @event.Name + "' was succesfully " + message);

                return RedirectToAction("AllEvents", "Events");
            }

            PopulateSelectionLists();

            return View("AdminFormCreation", @event);
        }

        /// <summary>
        /// Approves the edit event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditApprove(int? id)
        {
            TempData["FormType"] = "Approve";
            return RedirectToAction("Edit", new { id = id });
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (TempData["FormType"] != null)
                {
                    ViewBag.Type = TempData["FormType"].ToString();
                }
                else
                {
                    ViewBag.Type = "Edit";
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Event @event = db.Event.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }

                PopulateSelectionLists();

                return View("AdminFormCreation", @event);
            }
            else
            {
                Event evnt = new Event();
                return RedirectToAction("AdminFormCreation");
            }
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="evnt">The evnt<see cref="Event"/></param>
        /// <param name="file">The file<see cref="HttpPostedFileBase"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event evnt, HttpPostedFileBase file)
        {
            evnt.IsApproved = true;
            if (ModelState.IsValid)
            {
                TempData["FormType"] = "Save";
                evnt.Date = evnt.FullDate;
                db.Entry(evnt).State = EntityState.Modified;

                var DBEvent = (from e in db.Event
                               where e.EventId == evnt.EventId
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

                        DBEvent.Image = bytes;
                    }
                    else
                    {
                        ViewBag.Picture = "Invalid";
                        return View("AdminFormCreation", DBEvent);
                    }
                }

                // Open to suggestions on how to do this differently
                if (file == null && Session["Image"] != null)
                {
                    DBEvent.Image = (byte [])Session["Image"];
                }
                Session["Image"] = null;

                db.SaveChanges();

                SetFlash(enums.FlashMessageType.Success, "Event '" + evnt.Name + "' was succesfully updated");

                return RedirectToAction("AllEvents", "Events");
            }

            PopulateSelectionLists();
            return View("AdminFormCreation", evnt);
        }

        /// <summary>
        /// The DeleteConfirmed
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Delete(int id)
        {
            Event @event = db.Event.Find(id);
            @event.IsArchived = true;
            db.Entry(@event).State = EntityState.Modified;
            db.SaveChanges();

            SetFlash(enums.FlashMessageType.Success, "Event '" + @event.Name + "' was succesfully removed");
            return RedirectToAction("AllEvents");
        }

        /// <summary>
        /// Gets Creates the view for approving or denying all the pending events
        /// </summary>
        /// <param name="currentFilter">The currentFilter<see cref="string"/></param>
        /// <param name="searchString">The searchString<see cref="string"/></param>
        /// <param name="page">The page<see cref="int?"/></param>
        /// <returns></returns>
        public ActionResult PendingEvents(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.NavTag = "Pending Events";

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var events = SQLUtilities.GetPendingEvents();

            return View(events.ToPagedList(pageNumber, pageSize));
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
        /// Gets the clubs similar events.
        /// </summary>
        /// <param name="hostId">The list of hosts.</param>
        /// <returns>Returns the list of hosts</returns>
        public ObservableCollection<Event> GetSimilarEvents(int hostId)
        {
            string Procedure = "Similar Events";
            ObservableCollection<Event> Events = new ObservableCollection<Event>();

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@HostId", hostId);

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
                    evnt.City = reader["City"].ToString();
                    evnt.State = reader["State"].ToString();
                    evnt.Zip = (int)reader["Zip"];
                    evnt.FreeFood = Convert.ToBoolean(reader["FreeFood"].ToString());
                    evnt.FreeStuff = Convert.ToBoolean(reader["FreeStuff"].ToString());
                    evnt.RSVPCapable = Convert.ToBoolean(reader["RSVPCapable"].ToString());
                    try
                    {
                        evnt.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        evnt.Image = null;
                    }

                    if (!String.IsNullOrEmpty(reader["CategoryName"].ToString()))
                    {
                        evnt.CategoryName = reader["CategoryName"].ToString();
                    }

                    Events.Add(evnt);
                }

                Connection.Close();
            }
            return Events;
        }

        /// <summary>
        /// The GetEventById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Event"/></returns>
        private Event GetEventById(int id)
        {
            string Procedure = "Event By ID";
            Event evnt = new Event();

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@EventID", id);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    evnt.EventId = (int)reader["EventId"];
                    evnt.Name = reader["Name"].ToString();
                    evnt.Description = reader["Description"].ToString();
                    evnt.Date = Convert.ToDateTime(reader["Date"]);
                    evnt.Address = reader["Address"].ToString();
                    evnt.City = reader["City"].ToString();
                    evnt.State = reader["State"].ToString();
                    evnt.Zip = (int)reader["Zip"];
                    evnt.ClubHostId = (int)reader["ClubHostId"];
                    evnt.FreeFood = Convert.ToBoolean(reader["FreeFood"].ToString());
                    evnt.FreeStuff = Convert.ToBoolean(reader["FreeStuff"].ToString());
                    evnt.RSVPCapable = Convert.ToBoolean(reader["RSVPCapable"].ToString());
                    evnt.CampusHostId = Convert.ToInt32(reader["CampusHostId"]);
                    try
                    {
                        evnt.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        evnt.Image = null;
                    }

                    if (!String.IsNullOrEmpty(reader["CategoryName"].ToString()))
                    {
                        evnt.CategoryName = reader["CategoryName"].ToString();
                    }

                    evnt.EventHosts = this.GetHosts(id);
                }

                Connection.Close();
            }

            return evnt;
        }

        /// <summary>
        /// The GetHosts
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ObservableCollection{Club}"/></returns>
        private ObservableCollection<Club> GetHosts(int id)
        {
            string Procedure = "Event Hosts";
            ObservableCollection<Club> Hosts = new ObservableCollection<Club>();

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@EventID", id);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Club host = new Club();
                    host.ClubId = (int)reader["ClubId"];
                    host.Name = reader["Name"].ToString();
                    host.Description = reader["Description"].ToString();
                    try
                    {
                        host.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        host.Image = null;
                    }

                    Hosts.Add(host);
                }

                Connection.Close();
            }

            return Hosts;
        }

        /// <summary>
        /// Populates the selection lists for the events controller
        /// </summary>
        private void PopulateSelectionLists()
        {
            //populates the host dropdown with  clubs drom db
            List<SelectListItem> clubs = SQLUtilities.GetAllHosts();

            ViewData["ClubHosts"] = clubs;

            //Gets all the categories and creates selection list
            List<SelectListItem> cats = SQLUtilities.GetCategories();
            ViewData["cats"] = cats;

            List<SelectListItem> camp = new List<SelectListItem>();
            camp.Add(new SelectListItem() { Value = "1", Text = "Stevens Point" });
            camp.Add(new SelectListItem() { Value = "2", Text = "Wisconsin Rapids" });
            camp.Add(new SelectListItem() { Value = "3", Text = "Marshfield" });
            camp.Add(new SelectListItem() { Value = "4", Text = "Adams" });
            camp.Add(new SelectListItem() { Value = "5", Text = "Off Campus" });

            ViewData["campuses"] = camp;
        }
    }
}
