﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaunchPad.Controllers;
using LaunchPad.Repository;
using LaunchPad.Entities.Domain;
using LaunchPad.Data;
using System.Linq;

namespace LaunchPad.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            UnityConfig.RegisterComponents();
        }
        //[TestMethod]
        //public void Get()
        //{
        //    // Arrange
        //    var controller = new AppointmentController();

        //    // Act
        //    var result = controller.GetAppointment();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
        //[TestMethod]
        //public void Getcode()
        //{
            
        //    // Arrange
        //    var controller = new AppointmentController();

        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
        [TestMethod]
        public void Getcode()
        {
            var ClientData = new ClientUnitOfWork();
            var result = ClientData.Repository<Appointment>().GetAll();
            foreach(var i in result)
            {

                var x = i.Native_ID;
            }

            // Assert
            Assert.IsNotNull(result);
            // Assert.AreEqual(1000, result.Count());

        }

        [TestMethod]
        public void GetIO_Detail()
        {
            var ClientData = new UnitOfWork();
            var result = ClientData.Repository<tbl_io_detail>().GetAll().Where(x=>x.ad_position_id != null).ToList();
            foreach (var i in result)
            {

                var x = i.ad_position_id;
                var c = i.lu_adsize;
                var g = i.adsize_id;
                var v = i.lu_ad_position;
                var w = i.ad_position_id;

                var b = i.lu_ad_sect;
                var e = i.sect_id;

                var n = i.lu_ad_shape;
                var r = i.ad_shape_id;

                var m = i.lu_io_status;
                var t = i.status;

                var a = i.lu_iss;
                var y = i.iss_id;

                var s = i.lu_pub;
                var u = i.pub_id;

                var d = i.tbl_io;
                var p = i.io_id;

                var f = i.tbl_master;
            }

            // Assert
            Assert.IsNotNull(result);
            // Assert.AreEqual(1000, result.Count());

        }
        //[TestMethod]
        //public void GetMaster()
        //{
        //    // Arrange
        //    var controller = new MasterController();

        //    // Act
        //    var result = controller.GetMaster();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
    }
}
