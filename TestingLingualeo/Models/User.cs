using System;
using TestingLingualeo.Helpers;

namespace TestingLingualeo.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        public static User GetValidUserForLogin()
        {
            return new User()
            {
                Email = "ltybc3528@mail.ru",
                Password = "ltybc3528",
            };
        }
        
        public static User GetRandomUser()
        {
            var r = new Random((int)DateTime.Now.Ticks);
            return new User()
            {
                //Name = TextHelpers.GetRandomWord(10),
                Email = TextHelpers.GetRandomWord(10) + "@" + TextHelpers.GetRandomWord(6) + "." + TextHelpers.GetRandomWordWithoutNumbers(2),
                Password = TextHelpers.GetRandomWord(8) + r.Next(0, 9)
            };
        }
    }
}