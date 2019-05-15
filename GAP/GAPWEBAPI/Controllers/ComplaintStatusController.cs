using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAPWEBAPI.Models;

namespace GAPWEBAPI.Controllers
{
    public class ComplaintStatusController : ApiController
    {
        Tracking trk = new Tracking();
        public IHttpActionResult Get()
        {
            return Ok(trk.Complaints.ToArray());
        }

        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid id. should be greater than 0");
            }
            var Obj = trk.Complaints.Find(id);
            if (Obj == null)
            {
                return NotFound();
            }
            return Ok(Obj);
        }
    }
}
