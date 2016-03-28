using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MPositive.DAL;
using MPositive.Models;
using MPositive.Sync.Client;

namespace MPositive.Areas.SyncApi.Controllers
{
    public class UpdateProductsController : ApiController
    {
         // POST api/account/accountId/updateProducts
        public UpdateProductsResponseModel Post(int accountId, [FromBody] UpdateProductsRequestModel value)
        {
            var context = new SyncApiContext();
            var response = new UpdateProductsResponseModel();

            // TODO 404 if account doesnt exist
            // TODO auth
            // TODO logging
            // TODO async this biatch
            var productsForAccount = context.Products.Where(p => p.Account.Id == accountId).ToList();
            foreach (var product in value.Products)
            {
                var productToEdit = productsForAccount.SingleOrDefault(p => p.Id == product.Id);
                if (productToEdit != null)
                {
                    productToEdit.Name = product.Name;
                    productToEdit.Deleted = product.Deleted;
                    response.UpdatedProducts.Add(new UpdateProductResponseModel { ExternalId = product.ExternalId, Id = productToEdit.Id });
                }
            }

            context.SaveChanges();
            return response;
        }
    }
}
