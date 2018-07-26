﻿using BusinessLogicLayer.Repository;
using BusinessLogicLayer.Repository.Interface;
using BusinessObjects.Entities;
using MerchantDistributorService_API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace MerchantDistributorService_API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;
        public ProductController()
        {
            this._productRepository = new ProductRepository();
        }
        [HttpPost, DeflateCompression,Cache(TimeDuration =10)]
        public HttpResponseMessage GetProductList()
        {
            try
            {
                var response = _productRepository.GetAllProductDetails();
                if (response != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "NoContent");
                }
            }
            catch (Exception ex)
            {
                HttpError error = new HttpError(ex, true) { { "IsSuccess", false } };
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }
        }
    }
}
