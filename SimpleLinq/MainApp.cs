using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLinq
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

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}
