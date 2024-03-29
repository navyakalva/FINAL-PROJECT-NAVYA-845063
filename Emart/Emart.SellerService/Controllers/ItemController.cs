﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.SellerService.Models;
using Emart.SellerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emart.SellerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("AddItems")]
        public IActionResult AddItems(Items obj)
        {
            try
            {
                _repo.AddItems(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("ViewItems/{sid}")]
        public IActionResult ViewItems(int sid)
        {
            try
            {
                return Ok(_repo.ViewItems(sid));
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetAllItems")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteItems(int id)
        {
            try
            {
                _repo.DeleteItems(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
           
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateItems(Items obj)
        {

            try
            {
                _repo.UpdateItems(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
            
        }
        [HttpGet]
        [Route("GetItems/{id}")]
        public IActionResult GetItems(int id)
        {
            try
            {
                return Ok(_repo.GetItems(id));
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetCat()
        {
            try
            {
                return Ok(_repo.GetAllCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetSubCategory/{category_id}")]
        public IActionResult GetSub(int category_id)
        {
            try
            {
                return Ok(_repo.GetSubCategories(category_id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}