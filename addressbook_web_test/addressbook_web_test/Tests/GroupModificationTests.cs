﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupModificationTests:TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("first");
            newData.Footer = "qqqqq";
            newData.Header = "asd";
            app.Groups.Modify(1, newData);
        }

    }
}