using Microsoft.VisualStudio.TestTools.UnitTesting;
using models.Data;
using models.DataAcces;
using models.DataAcces;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace models.Data.Tests
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
            playermodel =  await data.GetUser(1);



            //result
            Assert.IsTrue(playermodel.playername == "leon");
        }
    }
}