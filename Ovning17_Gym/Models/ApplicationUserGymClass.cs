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
        public int GymClassId { get; set; }
        public string ApplicationUserId { get; set; }

        //NavigationProperties
        public GymClass GymClass { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    

}
