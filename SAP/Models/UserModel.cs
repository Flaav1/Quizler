using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace SAP.Models
{
    public class UserModel
    {
      public  List<User> users { get; set; }

        public UserModel()
        {
            users = new List<User>();
        }
    }
}