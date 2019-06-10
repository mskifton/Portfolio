namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="NewsViewModel" />
    /// </summary>
    public class NewsViewModel
    {
        /// <summary>
        /// Gets or sets the view models News articles.
        /// Gets or sets the News
        /// </summary>
        public ObservableCollection<News> News { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsViewModel"/> class.
        /// </summary>
        public NewsViewModel()
        {
        }
    }
}
