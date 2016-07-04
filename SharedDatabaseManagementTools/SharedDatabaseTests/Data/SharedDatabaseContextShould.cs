using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDatabaseTests.Data
{
    [TestFixture]
    public class SharedDatabaseContextShould
    {
        public SharedDatabaseContextShould()
        {
            //Database.SetInitializer(new TestInitializerForVetContext());
            //     AppDomain.CurrentDomain.SetData("DataDirectory", "");
        }

        [Test]
        //[Ignore]
        public void BuildModel()
        {
            //var db = new Conte();
            //db.Database.Initialize(true);
            // var clients = db.Clients.ToList();
        }
    }
}
