namespace Dalek_Mint.Controllers
{
    using Dalek_Mint.Models;
    using Dalek_Mint.Utilities;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="RSVPController" />
    /// </summary>
    public class RSVPController : ApiController
    {
        Dalek_Mint.DataAccess.MintContext db = new Dalek_Mint.DataAccess.MintContext();

        /// <summary>
        /// The EventRSVP
        /// </summary>
        /// <param name="UserId">The UserId<see cref="int"/></param>
        /// <param name="EventId">The EventId<see cref="int"/></param>
        /// <param name="RSVPChoice">The RSVPChoice<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        public IHttpActionResult EventRSVP(int EventId, short RSVPChoice, string Name, string Email)
        {
            try
            {
                //Inserting the new attendance rec
                EventAttendance ea = new EventAttendance();
                ea.EventId = EventId;
                ea.UserName = Name;
                ea.UserEmail = Email;
                ea.IsAttending = RSVPChoice;
                db.EventAttendance.Add(ea);
                db.SaveChanges();
                
                return Ok("Passed");
            }
            catch
            {
                return BadRequest("Failed");
            }
        }

        /// <summary>
        /// The Post
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        public IHttpActionResult Post()
        {
            return BadRequest();
        }
    }
}
