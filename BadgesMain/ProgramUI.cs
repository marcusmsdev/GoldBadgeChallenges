using Badges.UI;
using ChallengeBadgesThreeREPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Badges.UI
{
    class ProgramUI
    {
        private BadgeRepo _repoBadge = new BadgeRepo();
        private Badge badgeStore = new Badge();
        private Dictionary<int, List<string>> _dictionaryBadge = new Dictionary<int, List<string>>();

        public void Run()
        {
            Menu();
            Seed();            
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge.\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;

                    case "2":
                        BadgeRemove();
                        break;

                    case "3":
                        DisplayBadges();
                        break;

                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue... ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            _dictionaryBadge = _repoBadge.GetListOfBadges();

            Console.WriteLine("What is the number on the badge:");

            bool user = true;
            while (user)
            {
                string badgeIdAsString = Console.ReadLine();
                int num = -1;

                if (!int.TryParse(badgeIdAsString, out num))
                {
                    Console.WriteLine("Please enter an integer:");
                    user = true;
                }
                else
                {
                    int badgeIDUser = int.Parse(badgeIdAsString);

                    if (_repoBadge.IsBadgeIDPresent(badgeIDUser))
                    {
                        Console.WriteLine($"This Badge Id ({badgeIDUser}) is already present, please enter a new ID:");
                        user = true;
                    }
                    else
                    {
                        badgeStore.BadgeID = badgeIDUser;
                        user = false;
                    }
                }
            }

            Console.WriteLine("List a door that it needs access to:");
            string userInput = Console.ReadLine();

            List<string> userDoorsList = new List<string>();

            userDoorsList.Add(userInput.ToUpper());

            bool addMoreDoors = true;
            while (addMoreDoors)
            {
                Console.WriteLine("Any other doors(y/n)?");
                string userDecision = Console.ReadLine().ToLower();

                if (userDecision == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                    string doorToAdd = Console.ReadLine();

                    userDoorsList.Add(doorToAdd.ToUpper());
                    addMoreDoors = true;
                }
                else if (userDecision == "n")
                {
                    addMoreDoors = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection\n");
                    addMoreDoors = true;
                }
            }

            badgeStore.DoorsAccessible = userDoorsList;

            _repoBadge.AddBadgeToDictionary(badgeStore);
            _dictionaryBadge = _repoBadge.GetListOfBadges();

            Console.Write("\nThe following badge has been added:\n" +
                $"Badge ID: {badgeStore.BadgeID}\n" +
                $"Doors Accessible:");

            foreach (string door in _dictionaryBadge[badgeStore.BadgeID])
            {
                Console.Write($" {door},");
            }

            Console.WriteLine("\n");
        }

        private void BadgeRemove()
        {
            Console.Clear();
            _dictionaryBadge = _repoBadge.GetListOfBadges();

            Console.WriteLine("What is the badge number to update?");

            bool user = true;
            while (user)
            {
                string badgeIdAsString = Console.ReadLine();
                int num = -1;

                if (!int.TryParse(badgeIdAsString, out num))
                {
                    Console.WriteLine("Please enter an integer:");
                    user = true;
                }
                else
                {
                    int badgeIDUser = int.Parse(badgeIdAsString);

                    if (_repoBadge.IsBadgeIDPresent(badgeIDUser))
                    {
                        Console.Write($"\n{badgeIDUser} has access to doors:");

                        foreach (string door in _dictionaryBadge[badgeIDUser])
                        {
                            Console.Write($" {door},");
                        }

                        Console.WriteLine("\n\nWhat would you like to do?\n" +
                            "   1. Remove a door\n" +
                            "   2. Add a door\n" +
                            "   3. Remove all doors");

                        bool removeAddDoor = true;

                        while (removeAddDoor)
                        {
                            string userInputD = Console.ReadLine();

                            if (userInputD == "1")
                            {
                                Console.Write($"Which door would you like to remove? ");

                                bool removeDoor = true;

                                while (removeDoor)
                                {
                                    string doorToRemove = Console.ReadLine().ToUpper();
                                    if (_repoBadge.IsDoorPresent(badgeIDUser, doorToRemove))
                                    {
                                        _repoBadge.RemoveDoorFromBadge(badgeIDUser, doorToRemove);
                                        _dictionaryBadge = _repoBadge.GetListOfBadges();

                                        Console.WriteLine("\nDoor removed\n");

                                        Console.Write($"{badgeIDUser} has access to door/doors");

                                        foreach (string door in _dictionaryBadge[badgeIDUser])
                                        {
                                            Console.Write($" {door},");
                                        }

                                        Console.WriteLine("\n");
                                        removeDoor = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Door does not exist, please ensure you have the correct door and try again\n");
                                        removeDoor = true;
                                    }
                                }

                                user = false;
                                removeAddDoor = false;

                            }
                            else if (userInputD == "2")
                            {
                                Console.Write($"Which door would you like to add? ");

                                bool addDoor = true;

                                while (addDoor)
                                {
                                    string doorToAdd = Console.ReadLine().ToUpper();

                                    if (_repoBadge.IsDoorPresent(badgeIDUser, doorToAdd))
                                    {
                                        Console.WriteLine("Door already present\n");
                                        addDoor = true;
                                    }
                                    else
                                    {
                                        _repoBadge.AddDoorToBadge(badgeIDUser, doorToAdd);
                                        _dictionaryBadge = _repoBadge.GetListOfBadges();

                                        Console.WriteLine("\nDoor Added\n");

                                        Console.Write($"{badgeIDUser} has access to door/doors");

                                        foreach (string door in _dictionaryBadge[badgeIDUser])
                                        {
                                            Console.Write($" {door},");
                                        }

                                        Console.WriteLine("\n");
                                        addDoor = false;

                                    }
                                }

                                user = false;
                                removeAddDoor = false;
                            }
                            else if (userInputD == "3")
                            {
                                _repoBadge.RemoveAllDoorsFromBadge(badgeIDUser);
                                _dictionaryBadge = _repoBadge.GetListOfBadges();

                                Console.WriteLine("\nDoors removed\n");

                                Console.Write($"{badgeIDUser} has access to door/doors");

                                foreach (string door in _dictionaryBadge[badgeIDUser])
                                {
                                    Console.Write($" {door},");
                                }

                                Console.WriteLine("\n");

                                user = false;
                                removeAddDoor = false;

                            }
                            else
                            {
                                Console.WriteLine("Please select a valid entry\n");
                                removeAddDoor = true;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Badge ID: {badgeIDUser} does not exist, please verify and try again\n");
                        user = true;
                    }
                }
            }
        }

        private void DisplayBadges()
        {
            Console.Clear();

            _dictionaryBadge = _repoBadge.GetListOfBadges();

            String[] header = { "Badge #", "Door Access" };

            int[] columnWidth = TableBuilder(header, _dictionaryBadge);

            string[] widthH =
            {
                new string(' ', columnWidth[0] - header[0].Length),
            };

            Console.Write($"{header[0]}   " + $"{widthH[0]}" +
                $"{header[1]}");

            foreach (KeyValuePair<int, List<string>> badge in _dictionaryBadge)
            {
                string[] widthC =
                {
                new string(' ', columnWidth[0] - badge.Key.ToString().Length),
                };

                Console.Write($"\n{badge.Key.ToString()}   " + $"{widthC[0]}");

                foreach (string door in badge.Value)
                {
                    Console.Write($"{door} ,");
                }
            }

            Console.Write($"\n");
        }

        private int[] TableBuilder(string[] header, Dictionary<int, List<string>> _dictionaryBadge)
        {
            int[] tableWidth =
            {
            header[0].Length,
            };

            foreach (KeyValuePair<int, List<string>> content in _dictionaryBadge)
            {
                if (content.Key.ToString().Length > tableWidth[0])
                {
                    tableWidth[0] = content.Key.ToString().Length + 1;
                }
            }

            return tableWidth;
        }

        private void Seed()
        {
            int[] badgeIDs = { 1, 2, 3, 4, 5, 6, 7 };
            List<string> doorAccess1 = new List<string>() { "A1", "A2", "B3", "B4" };
            List<string> doorAccess2 = new List<string>() { "A4", "D2", "E6", "D8" };
            List<string> doorAccess3 = new List<string>() { "A6", "F2", "H3", "R5" };
            List<string> doorAccess4 = new List<string>() { "A7", "G2", "G5", "T33" };
            List<string> doorAccess5 = new List<string>() { "A8", "E2", "F4", "Y12" };
            List<string> doorAccess6 = new List<string>() { "C3", "A5", "S43", "Z6" };
            List<string> doorAccess7 = new List<string>() { "A1", "A12", "C3", "G5" };

            Badge badge1 = new Badge(badgeIDs[0], doorAccess1);
            Badge badge2 = new Badge(badgeIDs[1], doorAccess2);
            Badge badge3 = new Badge(badgeIDs[2], doorAccess3);
            Badge badge4 = new Badge(badgeIDs[3], doorAccess4);
            Badge badge5 = new Badge(badgeIDs[4], doorAccess5);
            Badge badge6 = new Badge(badgeIDs[5], doorAccess6);
            Badge badge7 = new Badge(badgeIDs[6], doorAccess7);

            _repoBadge.AddBadgeToDictionary(badge1);
            _repoBadge.AddBadgeToDictionary(badge2);
            _repoBadge.AddBadgeToDictionary(badge3);
            _repoBadge.AddBadgeToDictionary(badge4);
            _repoBadge.AddBadgeToDictionary(badge5);
            _repoBadge.AddBadgeToDictionary(badge6);
            _repoBadge.AddBadgeToDictionary(badge7);
        }
    }
}
