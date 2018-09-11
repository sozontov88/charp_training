using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class LoginTest :TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.LogOut();
            AccountData accaunt = new AccountData("admin", "secret");
            app.Auth.Login(accaunt);
            Assert.IsTrue(app.Auth.IsLogedIn(accaunt));
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.LogOut();
            AccountData accaunt = new AccountData("qqq", "wer");
            app.Auth.Login(accaunt);
            Assert.IsFalse(app.Auth.IsLogedIn(accaunt));
        }
    }
}
