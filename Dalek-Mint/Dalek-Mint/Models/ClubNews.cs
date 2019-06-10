namespace Dalek_Mint.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ClubNews" />
    /// </summary>
    public class ClubNews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClubNews"/> class.
        /// </summary>
        public ClubNews()
        {
        }

        /// <summary>
        /// Defines the clubs
        /// </summary>
        private Club clubs;

        /// <summary>
        /// Defines the clubId
        /// </summary>
        private int clubId;

        /// <summary>
        /// Defines the clubNewsId
        /// </summary>
        private int clubNewsId;

        /// <summary>
        /// Defines the news
        /// </summary>
        private News news;

        /// <summary>
        /// Defines the newsId
        /// </summary>
        private int newsId;

        /// <summary>
        /// Gets or sets the Clubs
        /// </summary>
        public virtual Club Clubs { get => clubs; set => clubs = value; }

        /// <summary>
        /// Gets or sets the ClubId
        /// </summary>
        public int ClubId { get => clubId; set => clubId = value; }

        /// <summary>
        /// Gets or sets the ClubNewsId
        /// </summary>
        [Key]
        public int ClubNewsId { get => clubNewsId; set => clubNewsId = value; }

        /// <summary>
        /// Gets or sets the News
        /// </summary>
        public virtual News News { get => news; set => news = value; }

        /// <summary>
        /// Gets or sets the NewsId
        /// </summary>
        public int NewsId { get => newsId; set => newsId = value; }
    }
}
