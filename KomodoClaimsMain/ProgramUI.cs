using ChallengeClaimsTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCafetwo
{
    public class ProgramUI
    {
        private ClaimsREPO _claimInfo = new ClaimsREPO();

        DateTime dateA = new DateTime(1998, 04, 17);
        DateTime dateB = new DateTime(2000, 12, 20);
        DateTime dateC = new DateTime(1980, 03, 26);
        DateTime dateD = new DateTime(1998, 06, 11);
        DateTime dateE = new DateTime(1998, 05, 02);
        DateTime dateAa = new DateTime(1998, 05, 18);
        DateTime dateBb = new DateTime(2000, 12, 28);
        DateTime dateCc = new DateTime(1980, 04, 25);
        DateTime dateDd = new DateTime(1998, 07, 12);
        DateTime dateEe = new DateTime(1998, 05, 11);

        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        DisplayAllClaims();
                        break;


                    case "2":
                        TakeCareOfClaim();
                        break;



                    case "3":

                        CreateNewClaim();
                        break;


                    case "4":

                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        private void CreateNewClaim()
        {
            Console.Clear();

            Claim newClaim = new Claim();

            //ClaimID
            Console.WriteLine("Enters the Claim ID:");
            int starId = Convert.ToInt32(Console.ReadLine());
            newClaim.ClaimID = starId;



            {

            }

            //Type of Claim
            Console.WriteLine("What type of Claim\n" +
            "1. Car\n" +
            "2. Home\n" +
            "3. Theft\n");

            string starTypeOfClaim = Console.ReadLine();
            int typeofClaimint = int.Parse(starTypeOfClaim);
            newClaim.TypeOfClaim = (ClaimType)typeofClaimint;

            _claimInfo.AddClaimToQueue(newClaim);

            //Description
            Console.WriteLine("Description of Claim:");
            newClaim.Description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("Claim Amount:");
            string starAmount = Console.ReadLine();
            newClaim.ClaimAmount = starAmount;


            //Date of Incident
            Console.WriteLine("Date Of Incident: ");

            bool userInput = true;
            while (userInput)
            {
                string accidentDateUser = Console.ReadLine();
                DateTime dateCheck = new DateTime();

                if (!DateTime.TryParse(accidentDateUser, out dateCheck))
                {
                    Console.WriteLine("Invalid date, please retry: ");
                    userInput = true;
                }
                else
                {
                    DateTime userDateOfAccident = DateTime.Parse(accidentDateUser);
                    if (userDateOfAccident > DateTime.Now)
                    {
                        Console.WriteLine("You can not enter a future date, please retry: ");
                        userInput = true;
                    }
                    else
                    {
                        newClaim.DateOfIncident = userDateOfAccident;
                        userInput = false;
                    }
                }
            }

            //Date of Claim
            Console.WriteLine("Date of Claim: ");

            bool userInputFinal = true;
            while (userInputFinal)
            {
                string userClaimDate = Console.ReadLine();
                DateTime dateCheck = new DateTime();

                if (!DateTime.TryParse(userClaimDate, out dateCheck))
                {
                    Console.WriteLine("Invalid date, please retry: ");
                    userInputFinal = true;
                }
                else
                {
                    DateTime userDateOfClaim = DateTime.Parse(userClaimDate);
                    if (userDateOfClaim < newClaim.DateOfIncident)
                    {
                        Console.WriteLine("The claim date can not be before the accident date, please retry: ");
                        userInputFinal = true;
                    }
                    else
                    {
                        newClaim.DateOfClaim = userDateOfClaim;
                        userInputFinal = false;
                    }
                }
            }
            Console.WriteLine($"This clam is {newClaim.IsValid}");
        }

        //Claim IsValid
        private void TakeCareOfClaim()
        {
            Console.Clear();
            Queue<Claim> _queueOfAllClaims = _claimInfo.GetClaimsQueue();
            bool user;
        
            if (_queueOfAllClaims is null || _queueOfAllClaims.Count == 0)
            {
                Console.WriteLine("There are no items in the queue");
                user = false;
            }
            else
            {
                String[] header = { "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" };
        
                Console.WriteLine("Here are the details for the next claim to be handled:\n\n" +
                    $"{header[0]}: {_queueOfAllClaims.Peek().ClaimID}\n\n" +
                    $"{header[1]}: {_queueOfAllClaims.Peek().TypeOfClaim}\n\n" +
                    $"{header[2]}: {_queueOfAllClaims.Peek().Description}\n\n" +
                    $"{header[3]}: ${_queueOfAllClaims.Peek().ClaimAmount}\n\n" +
                    $"{header[4]}: {_queueOfAllClaims.Peek().DateOfIncident.ToString("M/dd/yyyy")}\n\n" +
                    $"{header[5]}: {_queueOfAllClaims.Peek().DateOfClaim.ToString("M/dd/yyyy")}\n\n" +
                    $"{header[6]}: {_queueOfAllClaims.Peek().IsValid}\n\n" +
                    $"Do you want to deal with this claim now(y/n)?");
                user = true;
            }
        
            while (user)
            {
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    _claimInfo.RemoveClaimFromQueue();
                    user = false;
                }
                else if (userInput.ToLower() == "n")
                {
                    user = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid entry: (y/n)?");
                    user = true;
                }
            }
        
        }



        



        private void DisplayAllClaims()
        {
            Console.Clear();

            Queue<Claim> listOfClaims = _claimInfo.GetClaimsQueue();
            Console.WriteLine("ClaimID   Claim Type\tDescription\tClaim Amount\tDate of Incident\tDate of Claim\t\tIsValid\n");

            foreach (Claim content in listOfClaims)

            {

                Console.WriteLine($"  { content.ClaimID}\t  { content.TypeOfClaim}\t\t{content.Description}\t{content.ClaimAmount}\t{content.DateOfIncident}\t{content.DateOfClaim}\t{content.IsValid}\n");
                    
               
            }

        }
        
            
            



            private void Seed()
        {


            Claim claimsA = new Claim(1, ClaimType.Home, "Basement water", "$ 15,000.00", dateA, dateAa);
            Claim claimsB = new Claim(2, ClaimType.Car, "Car accident", "$ 4000.00", dateB, dateBb);
            Claim claimsC = new Claim(3, ClaimType.Theft, "Break in", "$ 600.00", dateC, dateCc);
            Claim claimsD = new Claim(4, ClaimType.Home, "Roof Damage", "$ 18,000.00", dateD, dateDd);
            Claim claimsE = new Claim(5, ClaimType.Home, "Water Damage", "$ 13,000.00", dateE, dateEe);

            _claimInfo.AddClaimToQueue(claimsA);
            _claimInfo.AddClaimToQueue(claimsB);
            _claimInfo.AddClaimToQueue(claimsC);
            _claimInfo.AddClaimToQueue(claimsD);
            _claimInfo.AddClaimToQueue(claimsE);

           
            
        }
        
    }
}
