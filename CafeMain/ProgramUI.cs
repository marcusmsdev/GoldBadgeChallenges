using CafeOneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCafe
{
    public class ProgramUI
    {
        private CafeOneREPO _menuInfo = new CafeOneREPO();
        public void Run()
        {
            MenuInfo();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            { 

            //Display the options to the user
            Console.WriteLine("Select a menu option:\n" +
                        "1. Create New Menu Item\n" +
                        "2. View All Menu Items\n" +
                        "3. Delete Menu Item\n" +
                        "4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewMealsMenu();
                    break;
                case "2":
                    DisplayAllMealsMenus();
                    break;
                case "3":
                    DeleteMealsMenu();
                    break;
                case "4":
                    Console.WriteLine("Have a great day!");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number 1 through 5");
                    break;
            }
            Console.WriteLine("Please press any key to continue");
            Console.ReadLine();
            Console.Clear();
                }
            }

        private void CreateNewMealsMenu()
        {
            Console.Clear();
            MealsMenu newMenu = new MealsMenu();

            //MealNumber
            Console.WriteLine("Enter the Meal Number:");
            int starNumber = int.Parse(Console.ReadLine());
            newMenu.MealNumber = starNumber;

            //MealName
            Console.WriteLine("Enter name of Meal:");
            newMenu.MealName = Console.ReadLine();

            //MealDescription
            Console.WriteLine("Enter Description of Meal:");
            newMenu.Description = Console.ReadLine();

            //MealIngredients
            Console.WriteLine("Enter the Ingredients of Meal:");
            newMenu.Ingredients = Console.ReadLine();

            //MealPrice
            Console.WriteLine("Enter the Price of Meal:");
            string starPrice = Console.ReadLine();
            newMenu.Price = starPrice;

            _menuInfo.AddMealContentToList(newMenu);
        }

        

        //view list of all menu items
        private void DisplayAllMealsMenus()
        {
            Console.Clear();
            List<MealsMenu> menuList = _menuInfo.GetMealMenu();

            foreach(MealsMenu content in menuList)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Meal Description: {content.Description}\n" +
                    $"Meal Ingredients: {content.Ingredients}\n" +
                    $"Meal Price: $ {content.Price}\n" +
                    $"----------------------------------------------------------------------------------------"
                    );
                
            }
        }

        private void DeleteMealsMenu()
            {

            DisplayAllMealsMenus();

            // get the menu number they want to remove
            Console.WriteLine("Enter the Menu Number you would like to remove:");

            int input = Convert.ToInt32(Console.ReadLine());

            //call the delete method
             bool wasDeleted = _menuInfo.RemoveMealMenuContent(input);

            //if the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The Menu Item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Menu item could not be deleted.");
            }
        }
        
       
        private void MenuInfo()
            {
                //Menu info
                MealsMenu menuA = new MealsMenu(1, "Veggie Deluxe", "Veggie Burger fries and drink", "Cucumber and onion sandwich with season fries and choice of beverage", "4.00");
                MealsMenu menuB = new MealsMenu(2, "Ham and Cheese", "Ham and cheese sandwhich with fries and drink", "Ham with cheese sandwich with season fries and choice of beverage", "4.00");
                MealsMenu menuC = new MealsMenu(3, "Double cheese burger", "Double Cheese Burger with fries and drink", "Ground beef with american cheese sandwhich with season fries and choice of beverage", "4.00");
                MealsMenu menuD = new MealsMenu(4, "Chicken Gordon", "Chicken Breast sandwhich with fries and drink", "Cucumber and onion sancwich with season fries and choice of beverage", "4.00");
                MealsMenu menuE = new MealsMenu(5, "Chilli BigDog", "Big Hotdog fries and drink", "Beef Hot dog with chilli sauce and season fries and choice of beverage", "4.00");

                _menuInfo.AddMealContentToList(menuA);
                _menuInfo.AddMealContentToList(menuB);
                _menuInfo.AddMealContentToList(menuC);
                _menuInfo.AddMealContentToList(menuD);
                _menuInfo.AddMealContentToList(menuE);
            }
    }
}









