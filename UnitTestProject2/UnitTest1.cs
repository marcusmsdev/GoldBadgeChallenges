using ChallengeClaimsTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject2
{ }//
 //   [TestClass]
 //   public class ClaimsRepoTest
 //   {
 //       private readonly ClaimsREPO _repo = new ClaimsREPO();
 //
 //       [TestInitialize]
 //       public void Arrange()
 //       {
 //           Claim newClaimF = new Claim(3, ClaimType.Car, "Crashed Deer", "$12,000.00", new DateTime(2019, 6, 12), new DateTime(2021, 7, 8));
 //           Claim newClaimG = new Claim(5, ClaimType.Theft, "broke in", "$14,000.00", new DateTime(2021, 7, 2), new DateTime(2021, 7, 8));
 //           _repo.AddClaimToQueue(newClaimF);
 //           _repo.AddClaimToQueue(newClaimG);
 //       }
 //
 //       [TestMethod]
 //       public void AddClaimToQueue_ClaimIsNull_ReturnFalse()
 //       {
 //           Claim newClaimH = null;
 //
 //           bool result = _repo.AddClaimToQueue(newClaimH);
 //
 //           Assert.IsFalse(result);
 //       }
 //
 //       [TestMethod]
 //       public void AddClaimToQueue_ClaimIsNotNull_ReturnTrue()
 //       {
 //           Claim newClaimR = new Claim(12, ClaimType.Home, "Water Damage", "$32,000.00", new DateTime(2020, 15, 8), new DateTime(2020, 16, 9));
 //
 //           bool result = _repo.AddClaimToQueue(newClaimR);
 //
 //           Assert.IsTrue(result);
 //           Assert.AreEqual(true, newClaimR.IsValid);
 //       }
 //
        //[TestMethod]
        //public void RemoveClaimFromQueue_ClaimsQueueIsNull_ReturnFalse()
        //{
        //    ClaimsREPO _repo1 = new ClaimsREPO();
        //
        //    bool result = _repo.RemoveClaimFromQueue(_repo1.GetClaimsQueue());
        //
        //    Assert.IsFalse(result);
        //}
        //
        //[TestMethod]
        //public void RemoveClaimFromQueue_ClaimsQueueIsNotNull_ReturnTrue()
        //{
        //    bool result = _repo.RemoveClaimFromQueue(_repo.GetClaimsQueue());
        //
        //    Assert.IsTrue(result);
        //}
   // }
//}
