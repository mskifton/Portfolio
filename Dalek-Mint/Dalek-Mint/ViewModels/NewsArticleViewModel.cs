namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;

    /// <summary>
    /// Defines the <see cref="NewsArticleViewModel" />
    /// </summary>
    public class NewsArticleViewModel
    {
        /// <summary>
        /// Gets or sets the Article
        /// </summary>
        public News Article { get; set; }

        /// <summary>
        /// Gets or sets the ClubName
        /// </summary>
        public string ClubName { get; set; }
        
        /// <summary>
        /// Gets or sets the clubs logo
        /// </summary>
        public byte[] ClubLogo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsArticleViewModel"/> class.
        /// </summary>
        public NewsArticleViewModel()
        {
        }
    }
}
