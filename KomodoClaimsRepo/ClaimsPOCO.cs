using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeClaimsTwoRepo
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claim

    {
        public int ClaimID { get; set; }

        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }

        public string ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public Claim() { }

        public Claim(int claimId, ClaimType typeOfClaim, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimId;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }


            public bool IsValid
        {
            get
            {
                TimeSpan span = DateOfClaim - DateOfIncident;
                return span.Days <= 30;
            }
        }


    }

    }

    



