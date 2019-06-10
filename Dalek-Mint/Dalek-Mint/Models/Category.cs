using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dalek_Mint.Models
{
    public class Category
    {
        /// <summary>
        /// Gets or sets the categories ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the categories name
        /// </summary>
        public string CategoryName { get; set; }

        public Category()
        {

        }
    }
}