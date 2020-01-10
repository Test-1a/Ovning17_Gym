using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_Gym.Models
{
    public class ApplicationUserGymClass
    {
        public int Id { get; set; }
        public int GymClassId { get; set; }
        public int ApplicationUserId { get; set; }

        public GymClass GymClass { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    

}
