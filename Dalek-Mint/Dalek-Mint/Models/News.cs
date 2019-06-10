namespace Dalek_Mint.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="News" />
    /// </summary>
    public class News
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="News"/> class.
        /// </summary>
        public News()
        {
            this.IsApproved = false;
            this.IsArchived = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsApproved
        /// Gets or sets whether the news is approved or not.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Defines the contact.
        /// </summary>
        private string contact;

        /// <summary>
        /// Defines the clubNews
        /// </summary>
        private ObservableCollection<ClubNews> clubNews;

        /// <summary>
        /// Defines the newsId
        /// </summary>
        private int newsId;

        /// <summary>
        /// Defines the title
        /// </summary>
        private string title;

        /// <summary>
        /// Defines the description
        /// </summary>
        private string description;

        /// <summary>
        /// Defines the article
        /// </summary>
        private string article;

        /// <summary>
        /// Defines the postedDate
        /// </summary>
        private DateTime postedDate;

        /// <summary>
        /// club posting news
        /// </summary>
        private int postedBy;

        /// <summary>
        /// Defines the logo
        /// </summary>
        [NotMapped]
        private string logo;

        /// <summary>
        /// Defines the logo
        /// </summary>
        [NotMapped]
        public byte[] ClubLogo { get; set; }

        /// <summary>
        /// Gets or sets the Logo
        /// </summary>
        public string Logo { get => logo; set => logo = value; }

        /// <summary>
        /// Gets or sets the ClubNews
        /// </summary>
        public ObservableCollection<ClubNews> ClubNews { get => clubNews; set => clubNews = value; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        [Required]
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// Gets or sets the club id, author of news
        /// </summary>
        public int PostedBy { get => postedBy; set => postedBy = value; }

        /// <summary>
        /// Gets or sets the NewsId
        /// </summary>
        public int NewsId { get => newsId; set => newsId = value; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Gets or sets the Article
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Article { get => article; set => article = value; }

        /// <summary>
        /// Gets or sets the PostedDate
        /// </summary>
        public DateTime PostedDate { get => postedDate; set => postedDate = value; }

        /// <summary>
        /// Gets or sets the contact who submitted the form.
        /// </summary>
        [Required]
        public string Contact { get => contact; set => contact = value; }

        /// <summary>
        /// Gets or sets the contact who submitted the form.
        /// </summary>
        [Required]
        public string ContactName { get; set ; }
    }
}
