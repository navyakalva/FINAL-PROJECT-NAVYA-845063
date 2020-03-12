﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Emart.AdminService.Models;
using Emart.AdminService.Repositories;
namespace Emart.Test
{
    [TestFixture]
    class TestAdminService
    {
        AdminRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AdminRepository(new EmartDBContext());
        }
        [Test]
        [Description("to Add Category")]
        public void TestAddCategory()
        {
            _repo.AddCategory(new Category()
            {
               CategoryId=12,
               CategoryName="Grocery",
               BriefDetails="cooking essentials" 
            });
        }
        [Test]
        [Description("to Add SubCategory")]
        public void TestAddSubCategory()
        {
            _repo.AddSubCategory(new SubCategory()
            {
                SubcategoryId = 12,
                SubcategoryName = "Pulses",
                BriefDetails = "cooking essentials",
                Gst=125,
                CategoryId=12
            });
        }
        [Test]
        public void TestGetAllCategory()
        {
            var result = _repo.GetAllCategories();
            Assert.NotNull(result);
            Assert.AreEqual(result.Count, 3);
        }
        [Test]
        public void TestGetAllSubCategory()
        {
            var result = _repo.GetAllSubCategories();
            Assert.NotNull(result);
            Assert.AreEqual(result.Count, 8);
        }
        [Test]
        [Description("to test by id")]
        public void TestGetCategory()
        {
            var result = _repo.GetById(1);
            Assert.IsNotNull(result);

        }
        [Test]
        [Description("to test by id")]
        public void TestGetSubCategory()
        {
            var result = _repo.GetBySid(1);
            Assert.IsNotNull(result);

        }
        [Test]
        [Description("to test Delete Category")]
        public void TestDeleteCategory()
        {
            _repo.DeleteCat(1);
            var x = _repo.GetById(1);
            Assert.Null(x);
        }
        [Test]
        [Description("to test Delete SubCategory")]
        public void TestDeleteSubCategory()
        {
            _repo.DeleteSub(1);
            var x = _repo.GetBySid(1);
            Assert.Null(x);
        }
        [Test]
        [Description("to test update Category")]
        public void TestUpdateCategory()
        {
            Category c = _repo.GetById(12);
           c.CategoryName = "Groceries";
            _repo.UpdateCat(c);
            Category c1 = _repo.GetById(12);
            Assert.AreSame(c, c1);

        }
        [Test]
        [Description("to test update SubCategory")]
        public void TestUpdateSubCategory()
        {
            SubCategory c = _repo.GetBySid(82);
            c.BriefDetails = "Traditional";
            _repo.UpdateSub(c);
            SubCategory c1 = _repo.GetBySid(82);
            Assert.AreSame(c, c1);

        }


    }
}