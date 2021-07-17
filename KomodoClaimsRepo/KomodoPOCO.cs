using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoClaims
{
    public enum ClaimType
    {
        Car = 1,
        Home, 
        Theft       
    }
    
    public class ClaimProperties
    
    {
        public int ClaimID { get; set; }

        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }

        public string ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }






    }
}