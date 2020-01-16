using System;


namespace TestingLingualeo.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Patronim { get; set; }
        public string Nickname { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Gender { get; set; }
        public string PathAvatar { get; set; }
        
        public string GetGender()
        {
            switch (this.Gender)
            {
                case Sex.Male:
                    return "male";
                case Sex.Female:
                    return "female";
                
            }

            return null;
        }

        public static UserProfile GetValidUserForProfile()
        {
            return new UserProfile()
            {
                Name = "Денис",
                Patronim = "Иванов",
                Nickname = "Den",
                City = "Белгород",
                BirthDate = new DateTime(1998, 2, 28),
                Gender = Sex.Male,
                PathAvatar = "D:\\TestingLingualeo\\TestingLingualeo\\Images\\test_big_avatar.jpg"
            };
        }
    }
    
    public enum Sex
    {
        Male,
        Female
    }
}