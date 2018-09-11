using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTest
{
    [TestFixture]
    public class RemoveContactsTests: AuthTestBase
    {
        [Test]
        public void RemoveContact()
        {
            app.Contacts.Remove("1");
                
          
        }
    }
}
