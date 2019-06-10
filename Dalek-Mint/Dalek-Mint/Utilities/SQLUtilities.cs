namespace Dalek_Mint.Utilities
{
    using Dalek_Mint.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="SQLUtilities" />
    /// </summary>
    public static class SQLUtilities
    {
        /// <summary>
        /// Gets all the clubs that match the search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static ObservableCollection<Club> GetAllClubs(string search)
        {
            ObservableCollection<Club> Clubs = new ObservableCollection<Club>();

            string Procedure = "All Clubs";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("search", search);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Club club = new Club();

                    club.ClubId = (int)reader["ClubId"];
                    club.Name = reader["Name"].ToString();
                    club.Description = reader["Description"].ToString();
                    try
                    {
                        club.Image = (byte[])reader["Image"];
                    }
                    catch
                    {
                        club.Image = null;
                    }

                    Clubs.Add(club);
                }

                Connection.Close();

                return Clubs;
            }
        }

        /// <summary>
        /// Creates the RSVP for the event
        /// </summary>
        /// <param name="RSVPChoice"></param>
        /// <param name="userId"></param>
        /// <param name="eventId"></param>
        public static void RSVPEvent(int RSVPChoice, int userId, int eventId)
        {
            string Procedure = "RSVP For Event";
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@EventId", eventId);
            Command.Parameters.AddWithValue("@UserId", userId);
            Command.Parameters.AddWithValue("@RSVPChoice", RSVPChoice);

            using (Connection)
            {
                Connection.Open();
                Command.ExecuteNonQuery();

                Connection.Close();
            }
        }

        /// <summary>
        /// Gets the categories from DB to generate selection list
        /// </summary>
        /// <returns>selection list of categoies</returns>
        public static List<SelectListItem> GetCategories()
        {
            List<SelectListItem> Categories = new List<SelectListItem>();

            string Procedure = "Categories";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Categories.Add(new SelectListItem
                    {
                        //assigning the  value to be the Category id
                        Value = reader["Id"].ToString(),
                        //Text user sees is the Category name
                        Text = reader["Name"].ToString()
                    });
                }

                Connection.Close();
            }

            return Categories;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        /// <summary>
        /// Gets all the events that match the search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Event> GetAllEvents(string search = null, int? category = null, bool? freefood = null, bool? freestuff = null, string Date = null, bool? Weekend = null)
        {
            List<Event> Events = new List<Event>();

            string Procedure = "Upcoming Events";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("search", search);
            Command.Parameters.AddWithValue("category", category);
            Command.Parameters.AddWithValue("freestuff", freestuff);
            Command.Parameters.AddWithValue("freefood", freefood);
            Command.Parameters.AddWithValue("date", Date);
            Command.Parameters.AddWithValue("Weekend", Weekend);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
  
                    Event evnt = new Event();

                    evnt.Name = reader["Name"].ToString();
                    evnt.EventId = (int)reader["EventId"];

                    if (evnt.Name.Length > 20)
                    {
                        string newName = evnt.Name.Substring(0, 19);
                        newName += "...";
                        evnt.Name = newName;
                    }

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
        /// Gets all the news that matches the search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<News> GetAllNews(string search)
        {
            List<News> AllNews = new List<News>();

            string Procedure = "Recent News";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("search", search);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    News news = new News();

                    news.NewsId = (int)reader["NewsId"];
                    news.Title = reader["Title"].ToString();
                    news.Description = reader["Description"].ToString();
                    news.PostedDate = Convert.ToDateTime(reader["PostedDate"]);
                    news.Article = reader["Article"].ToString();
                    try
                    {
                        news.ClubLogo = (byte[])reader["Image"];
                    }
                    catch
                    {
                        news.ClubLogo = null;
                    }
                    if (news.Article.Length >= 25)
                    {
                        string newName = news.Article.Substring(0, 25);
                        newName += "...";
                        news.Article = newName;
                    }

                    AllNews.Add(news);
                }

                Connection.Close();
            }

            return AllNews;
        }

        /// <summary>
        /// gets all the clubids and corresponding names to fill in selected item list
        /// </summary>
        /// <returns>select list item</returns>
        public static List<SelectListItem> GetAllHosts()
        { 

            string Procedure = "Hosts";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                var clubs = new List<SelectListItem>();
                clubs.Add(new SelectListItem() { Text = "No Host", Value = "0" });
                clubs.Add(new SelectListItem() { Text = "Community", Value = "99" });
                while (reader.Read())
                {
                    clubs.Add(new SelectListItem
                    {
                        //assigning the  value to be the clud id
                        Value = reader["ClubId"].ToString(),
                        //Text user sees is the clubs name
                        Text = reader["Name"].ToString()
                    });


                }

                Connection.Close();
                

                return clubs;
            }
        }


        /// <summary>
        /// Gets the pending events for th admin to approve or deny
        /// </summary>
        public static List<Event> GetPendingEvents()
        {
            List<Event> Events = new List<Event>();

            string Procedure = "Pending Events";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {

                    Event evnt = new Event();

                    evnt.EventId = (int)reader["EventId"];
                    evnt.Name = reader["Name"].ToString();

                    if (evnt.Name.Length > 20)
                    {
                        string newName = evnt.Name.Substring(0, 19);
                        newName += "...";
                        evnt.Name = newName;
                    }

                    evnt.Description = reader["Description"].ToString();
                    evnt.Date = Convert.ToDateTime(reader["Date"]);
                    evnt.Address = reader["Address"].ToString();
                    evnt.CategoryName = reader["CategoryName"].ToString();
                    evnt.ContactName = reader["ContactName"].ToString();
                    evnt.Contact = reader["Contact"].ToString();
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
        /// Gets the pending events for th admin to approve or deny
        /// </summary>
        public static List<News> GetPendingNews()
        {
            List<News> News = new List<News>();

            string Procedure = "Pending News";

            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {

                    News news = new News();

                    news.NewsId = (int)reader["NewsId"];
                    news.Title = reader["Title"].ToString();
                    news.Description = reader["Description"].ToString();

                    if (news.Description.Length > 35)
                    {
                        string newName = news.Description.Substring(0, 19);
                        newName += "...";
                        news.Description = newName;
                    }

                    news.PostedDate = Convert.ToDateTime(reader["PostedDate"]);
                    news.PostedBy = (int)reader["PostedBy"];
                    news.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    news.Contact = reader["Contact"].ToString();
                    news.ContactName = reader["ContactName"].ToString();

                    News.Add(news);


                }

                Connection.Close();
            }

            return News;
        }
    }
}
