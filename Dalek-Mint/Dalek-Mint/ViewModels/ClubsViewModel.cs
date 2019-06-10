namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="ClubViewModel" />
    /// </summary>
    public class ClubViewModel
    {
        /// <summary>
        /// Gets or sets the Clubs
        /// </summary>
        public ObservableCollection<Club> Clubs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClubViewModel"/> class.
        /// </summary>
        public ClubViewModel()
        {
        }
    }
}
