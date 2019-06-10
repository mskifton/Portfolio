namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.DataAccess;
    using Dalek_Mint.Models;
    using Dalek_Mint.Utilities;
    using Dalek_Mint.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Data.SqlTypes;
    using PagedList;

    /// <summary>
    /// Defines the <see cref="NewsController" />
    /// </summary>
    public class NewsController : BaseController
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
            return View(db.News.ToList());
        }

        /// <summary>
        /// The AllNews
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult AllNews(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.NavTag = "News";
            string search = Request.QueryString["search"];

            if (search == null)
            {
                search = "";
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var news = SQLUtilities.GetAllNews(search);


            //look below @AsianCarp let me know if this may help ?? not sure how you plan but yeah 
            //FindArticleLogo(news);

            ViewBag.SearchTerm = search;

            return View(news.ToPagedList(pageNumber, pageSize));
        }



        /// <summary>
        /// Approves the news and then goes to the all events view
        /// </summary>
        /// <param name="Eventid"></param>
        /// <returns></returns>
        public ActionResult Approve(int id)
        {
            ApproveEvent(id);

            return RedirectToAction("PendingNews");
        }

        /// <summary>
        /// Approves the news with the passed in eventid
        /// </summary>
        /// <param name="eventid"></param>
        private void ApproveEvent(int id)
        {
            var News = (from e in db.News
                         where e.NewsId == id
                         select e).FirstOrDefault();

            if (News.NewsId != 0)
            {
                News.IsApproved = true;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Denys the news and then goes to the all events view
        /// </summary>
        /// <param name="Eventid"></param>
        /// <returns></returns>
        public ActionResult Deny(int id)
        {
            DenyEvent(id);

            //Viewbag to show message
            return RedirectToAction("PendingNews");
        }

        /// <summary>
        /// Approves the news with the passed in eventid
        /// </summary>
        /// <param name="eventid"></param>
        private void DenyEvent(int id)
        {
            var News = (from e in db.News
                        where e.NewsId == id
                         select e).FirstOrDefault();

            if (News.NewsId != 0)
            {
                News.IsApproved = false;
                News.IsArchived = true;
            }
            db.SaveChanges();
        }


        //private static List<News> FindArticleLogo(List<News> news)
        //{
        //    foreach(News item in news)
        //    {
        //        string newsLogo = "";

        //        if (item.Logo == null)
        //        {
        //            item.Logo = "~/images/img-placeholder.png";
        //        }
        //        else
        //        {
        //            // waiting for asher...
        //        }
        //    }

        //}

        /// <summary>
        /// The News
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult News(int id)
        {
            ViewBag.NavTag = "News";

            NewsArticleViewModel news = GetNewsArticle(id);

            return View(news);
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
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        /// <summary>
        /// The AdminNewsForm
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult AdminNewsForm()
        {
            ViewBag.NavTag = "AdminNewsForm";

            PopulateSelectionList();

            return View();
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
        /// <param name="news">The news<see cref="News"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            string message = "submitted";

            if (news != null)
            {
                DateTime tdy = DateTime.Now;
                news.PostedDate = (DateTime)new SqlDateTime(tdy);

            }

            if (ModelState.IsValid)
            {
                if (Session["Admin"] != null)
                {
                    news.IsApproved = true;
                    message = "created";

                }

                db.News.Add(news);
                db.ClubNews.Add(new ClubNews { ClubId = 1, NewsId = news.NewsId });
                db.SaveChanges();

                SetFlash(enums.FlashMessageType.Success, "Article '" + news.Title + "' was succesfully " + message);


                return RedirectToAction("AllNews");
            }

            PopulateSelectionList();

            return View("AdminNewsForm", news);
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
            if (TempData["FormType"] != null)
            {
                ViewBag.Type = TempData["FormType"].ToString();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            PopulateSelectionList();

            return View("AdminNewsForm",news);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="news">The news<see cref="News"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            DateTime tdy = DateTime.Now;
            news.PostedDate = (DateTime)new SqlDateTime(tdy);
            news.IsApproved = true;
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();

                SetFlash(enums.FlashMessageType.Success, "Article '" + news.Title + "' was succesfully updated");

                return RedirectToAction("AllNews");
            }


            PopulateSelectionList();

            return View("AdminNewsForm", news);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    News news = db.News.Find(id);
        //    if (news == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(news);
        //}

        /// <summary>
        /// The DeleteConfirmed
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>

        public ActionResult Delete(int id)
        {
            News news = db.News.Find(id);
            news.IsArchived = true;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();

            SetFlash(enums.FlashMessageType.Success, "Article '" + news.Title + "' was succesfully removed");

            return RedirectToAction("AllNews");
        }

        /// <summary>
        /// Gets Creates the view for approving or denying all the pending news
        /// </summary>
        /// <returns></returns>
        public ActionResult PendingNews(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //filtering in the future...
            //ViewBag.CurrentFilter = searchString;

            ViewBag.NavTag = "Pending News";

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var news = SQLUtilities.GetPendingNews();

            return View(news.ToPagedList(pageNumber, pageSize));
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
        /// The GetNewsArticle
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="NewsArticleViewModel"/></returns>
        private NewsArticleViewModel GetNewsArticle(int id)
        {
            string Procedure = "News By Id";
            NewsArticleViewModel newsArticle = new NewsArticleViewModel();

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NewsId", id);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    newsArticle.Article = new News();

                    newsArticle.Article.NewsId = (int)reader["NewsId"];
                    newsArticle.Article.Title = reader["Title"].ToString();
                    newsArticle.Article.Description = reader["Description"].ToString();
                    newsArticle.Article.Article = reader["Article"].ToString();
                    newsArticle.Article.PostedDate = Convert.ToDateTime(reader["PostedDate"]);
                    try
                    {
                        newsArticle.ClubName = reader["Name"].ToString();
                    }
                    catch
                    {
                        newsArticle.ClubName = "Mid-State";
                    }
                    try
                    {
                        newsArticle.ClubLogo = (byte[])reader["Image"];
                    }
                    catch
                    {
                        newsArticle.ClubLogo = null;
                    }
                }

                Connection.Close();
            }

            return newsArticle;
        }

        /// <summary>
        /// Populates the posted by selection list
        /// </summary>
        private void PopulateSelectionList()
        {
            List<SelectListItem> clubs = SQLUtilities.GetAllHosts();
            ViewData["ClubHosts"] = clubs;
        }
    }
}
