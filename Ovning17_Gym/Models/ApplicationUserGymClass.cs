using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_Gym.Models
{
    public class ApplicationUserGymClass
    {
        //Not needed due to using composit key
        //public int Id { get; set; }

        //Foreign keys
        public int GymClassId { get; set; }

        //string, not int because AppUser inherits of IdentityUser 
        //which takes a string
        public string ApplicationUserId { get; set; }

        //NavigationProperties
        public GymClass GymClass { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    

}
