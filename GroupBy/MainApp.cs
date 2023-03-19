using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){ Name="윤현우", Height = 184 },
                new Profile(){ Name="윤도영", Height = 168 },
                new Profile(){ Name="강이연", Height = 167 },
                new Profile(){ Name="이석현", Height = 183 },
                new Profile(){ Name="서경원", Height = 171 }
            };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 175 into g
                              select new { GroupKey = g.Key, Profiles = g };

            foreach (var Group in listProfile)
            {
                Console.WriteLine($"- 175cm 미만? : {Group.GroupKey}");

                foreach (var profile in Group.Profiles)
                {
                    Console.WriteLine($">>> {profile.Name}, {profile.Height}");
                }
            }
        }
    }
}
