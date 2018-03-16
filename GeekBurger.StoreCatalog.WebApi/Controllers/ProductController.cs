﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GeekBurger.StoreCatalog.Entities;
using GeekBurger.StoreCatalog.Core.Interfaces;

namespace GeekBurger.StoreCatalog.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private IProductCore _productCore;

        public ProductController(IProductCore productCore)
        {
            _productCore = productCore;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return all products for user with restrictions
        /// </summary>
        /// <param name="user">User with restrictions</param>
        /// <returns></returns>
        [HttpGet]
        [Route("products/{user}")]
        public IActionResult GetProducts([FromBody] User user)
        {
            var result = new OperationResult<IEnumerable<Product>>();

            try
            {
                // verifica se o usuário tem restrição // get ingredients/{restrictions}/products

                // recebe um status code 200 com os resultados

                // filtra os produtos por restruições e áreas disponíveis

                // retorna os produtos

                result.Data = _productCore.GetAllProductsAvaliables();
                result.Success = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;

                return BadRequest(result);
            }
        }
    }
}