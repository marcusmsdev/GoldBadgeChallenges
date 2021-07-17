using CafeOneRepo;
using ChallengeCafe;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTestProject1

{ }
//{
    //[TestClass]
    //public class CafeRepoTest
    //{
    //    private readonly CafeOneREPO _repo = new CafeOneREPO();
    //
    //    [TestInitialize]
    //    public void Arrange()
    //    {
    //        MealsMenu mItem1 = new MealsMenu(7, "Cheese Sandwich", "American cheese sandwich in toast bread", "Black pepper", "$12.00" );
    //        _repo.AddMealContentToList(mItem1);
    //    }
    //
    //    [TestMethod]
    //    public void AddMealsMenu_MealsMenuisNull_ReturnFalse()
    //    {
    //        MealsMenu mealItem = null;
    //        CafeOneREPO repo = new CafeOneREPO();
    //
    //        bool result = repo.AddMealContentToList(mealItem);
    //
    //        Assert.IsFalse(result);
    //    }
    //
    //    [TestMethod]
    //    public void AddMealsMenu_MealsMenuisnotNull_ReturnTrue()
    //    {
    //        MealsMenu mItem = new MealsMenu(2, "Cheese Sandwich", "American cheese sandwich in toast bread", );
    //        CafeOneREPO repo = new CafeOneREPO();
    //
    //        bool result = repo.AddMealContentToList(mItem);
    //
    //        Assert.IsTrue(result);
    //    }
    //
    //    [TestMethod]
    //    public void GetMealsMenuByNumber_MealsMenuExists_ReturnMovie()
    //    {
    //        int id = 1;
    //
    //        MealsMenu result = _repo.GetMealsMenuByNumber(id);
    //
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(result.MealNumber, id);
    //    }
    //
    //    [TestMethod]
    //    public void GetMealsMenuByNumber_MealsMenuDoesntExist_ReturnNull()
    //    {
    //        int id = 1234;
    //
    //        MealsMenu result = _repo.GetMealsMenuByNumber(id);
    //
    //        Assert.IsNull(result);
    //    }
    //
    //    [TestMethod]
    //    public void DeleteMealsMenu_MealsMenuDoesntExist_ReturnNull()
    //    {
    //        int id = 1234;
    //
    //        bool result = _repo.DeleteMealsMenu(id);
    //
    //        Assert.IsFalse(result);
    //    }
    //
    //    [TestMethod]
    //    public void DeleteMealsMenu_MealsMenuExist_ReturnTrue()
    //    {
    //        int id = 1;
    //
    //        bool result = _repo.DeleteMealsMenu(id);
    //
    //        Assert.IsTrue(result);
    //    }
    //    //testm
    //}
