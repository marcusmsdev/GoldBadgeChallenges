using ChallengeCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOneRepo
{
    public class CafeOneREPO
    {

        private List<MealsMenu> _listOfMeals = new List<MealsMenu>();

        //CRUD

        //Create
        public void AddMealContentToList(MealsMenu mealcontent)
        {
            _listOfMeals.Add(mealcontent);
        }   

        //Read

        public List<MealsMenu> GetMealMenu()
        {
            return _listOfMeals;
        }

        //Update

        //Delete


        public bool RemoveMealMenuContent(int mealnumber)
        {
            MealsMenu mealcontent = GetMealNumber(mealnumber);

            if (mealcontent == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(mealcontent);

            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            public MealsMenu GetMealNumber(int mealnumber)
            {
                foreach (MealsMenu mealcontent in _listOfMeals)
                {
                    if (mealcontent.MealNumber == mealnumber)
                    {
                        return mealcontent;
                    }
                }
                return null;
            }

        }



        
    }

