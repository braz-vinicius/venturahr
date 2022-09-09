using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaHR.Domain.Models
{
    public class StatsResponse
    {
        public int TotalRegisteredUsers { get; set; }

        public int TotalJobs { get; set; }

        public int TotalJobApplicants { get; set; }

        public int TotalJobCriterias { get; set; }

    }
}
