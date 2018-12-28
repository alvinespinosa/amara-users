using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amara.UserManagement.Controllers
{
    public class AdminController: ControllerBase
    {
        [HttpGet("admin/heartbeat")]
        public string Heartbeat()
        {
            //this.logger.LogInformation("Heartbeat requested");
            return DateTime.Now.ToString("yyy-MM-ddTHH:mm:ssK") + "AlvinE";
        }
    }
}
