using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularCURD.Models
{
    public class UserViewModel
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }

        public string CreateTime { get; set; }

        public int Age { get; set; }

        public string Status { get; set; }

        public static IEnumerable<UserViewModel> GetUserList()
        {
            for (int i = 0; i < 132; i++)
            {
                yield return new UserViewModel()
                {
                    UserID=i,
                    Age=i%20,
                    CreateTime=DateTime.Now.AddMinutes(-(i%20)).ToString("yyyy-MM-dd HH:mm:ss"),
                    UserName=$"User{i}",
                    UserRole=i%3==0?"Admin":"User",
                    Status=i%10==0?"Enable": "Disable",
                    Email=$"Email{i}@angular.com"
                };
            }
        }
    }
}