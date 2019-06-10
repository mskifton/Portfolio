namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.enums;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="BaseController" />
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// The SetFlash for notification messages.
        /// </summary>
        /// <param name="type">The type<see cref="FlashMessageType"/></param>
        /// <param name="text">The text<see cref="string"/></param>
        public void SetFlash(FlashMessageType type, string text)
        {
            TempData["FlashMessage.Type"] = type;
            TempData["FlashMessage.Text"] = text;
        }
    }
}
