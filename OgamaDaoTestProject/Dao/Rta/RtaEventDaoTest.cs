﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OgamaDao.Dao.Rta;
using OgamaDao.Model.Rta;

namespace OgamaDaoTestProject.Dao.Rta
{
    [TestClass]
    public class RtaEventDaoTest : BaseGenericCrudTest<RtaEvent>
    {
        [TestInitialize]
        public void Init()
        {
            base.entity = new RtaEvent();
            base.cut = new RtaEventDao();
            base.Setup();
        }

        [TestMethod]
        public void TestUpdateEventWithCategory()
        {
            RtaCategoryDao categoryDao = new RtaCategoryDao();
            categoryDao.initFileBasedDatabase(databaseFile);
            RtaEventDao rtaEventDao = new RtaEventDao();
            rtaEventDao.initFileBasedDatabase(databaseFile);

            RtaCategory category1 = new RtaCategory();
            categoryDao.save(category1);

            RtaEvent event1 = new RtaEvent();
            
            event1.fkRtaCategory = category1;
            rtaEventDao.save(event1);

            RtaEvent event2 = rtaEventDao.findById(event1);
            Assert.IsNotNull(event2);
            Assert.AreEqual(event1.ID, event2.ID);

        }
    }
}