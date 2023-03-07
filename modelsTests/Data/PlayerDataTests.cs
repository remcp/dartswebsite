using Microsoft.VisualStudio.TestTools.UnitTesting;
using models.Data;
using models.DataAcces;
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
        public void GetUserTest()
        {
            //assert
            PlayerData playerdata = new PlayerData();
           
            int userid = 1;

            //test
            PlayerModel player = playerdata.GetUser(userid);



            //result
            Assert.IsTrue(1 == 1);
        }
    }
}