using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWeaverAdminTool.WebAPI.ViewModels
{
    public class LoginAccessViewModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
    }
}