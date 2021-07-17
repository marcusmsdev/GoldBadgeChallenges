using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCafe
{
    public class MealsMenu
    {
        public int MealNumber { get; set; }

        public string MealName { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Price { get; set; }

        public MealsMenu() {}

        public MealsMenu(int mealnumber, string mealname, string description, string ingredients, string price)
        {
            MealNumber = mealnumber;
            MealName = mealname;
            Description = description;
            Ingredients = ingredients;
            Price = price;

        }

    }

 }
