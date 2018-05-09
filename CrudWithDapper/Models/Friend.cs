using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithDapper.Models
{
    public class Friend
    {
        public int FriendID { get; set; }
        public string FriendName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}