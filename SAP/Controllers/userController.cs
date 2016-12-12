using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAP.Models;
using DAL;

namespace SAP.Controllers
{
    public class userController : ApiController
    {

        public IHttpActionResult Get()
        {
            try
            {
                using (var db = new QuizGameEntities())
                {
                    System.Threading.Thread.Sleep(2000);
                    return Ok(db.Users.ToList());
                }

            }
            catch (Exception ex)
            {

                return BadRequest("Error : " + ex);
            }
           
        }




        public IHttpActionResult Post([FromBody]User usr)
        {

            if(usr != null)
            {
                using (var db = new QuizGameEntities())
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
