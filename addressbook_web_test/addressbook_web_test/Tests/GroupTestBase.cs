﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    public class GroupTestBase: AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if(PERFORM_LONG_UI_CHECKS)
            {
             List<GroupData> fromUi = app.Groups.GetAllGroups();
             List<GroupData> fromDb = GroupData.GetAll();
             fromUi.Sort();
             fromDb.Sort();
             Assert.AreEqual(fromUi, fromDb);
            }
           
        }
    }
}
