using models.DataAcces;
using models.Data;
using models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dartswebsite.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dartswebsite.Pages.Tests
{
    [TestClass()]
    public class PlayerDataTests
    {
        [TestMethod()]
        public static async Task GetUserTest(IPlayerData data)
        {
            //assert
            PlayerModel playermodel = new PlayerModel();

            int userid = 1;

            //test
            playermodel = await data.GetUser(1);



            //result
            Assert.IsTrue(playermodel.playername == "leon");
        }
    }
}