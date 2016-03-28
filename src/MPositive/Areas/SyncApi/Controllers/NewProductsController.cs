using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using MPositive.DAL;
using MPositive.Models;
using MPositive.Sync.Client;

namespace MPositive.Areas.SyncApi.Controllers
{
    public class NewProductsController : ApiController
    {
        // POST api/account/accountId/newProducts
        public NewProductsResponseModel Post(int accountId, [FromBody]NewProductsRequestModel value)
        {
            // TODO make all this asynchronous and parallelelel
            // TODO, this creates an account if it doesnt exist, kill this later on when we have a way to register accounts
            // TODO logging
            // TODO authentication
            var context = new SyncApiContext();

            AccountModel account = context.Accounts.Find(accountId);
            if (account == null)
            {
                account = new AccountModel {Id = accountId};
                context.Accounts.Add(account);
                context.SaveChanges();
            }

            var response = new NewProductsResponseModel();
            foreach (var product in value.Products)
            {
                var newProduct = new ProductModel() { Account = account };
                context.Products.Add(newProduct);
                context.SaveChanges();
                response.CreatedProducts.Add(new NewProductResponseModel { ExternalId = product.ExternalId, Id = newProduct.Id });
            }

            //Parallel.ForEach(value.Products, p => SaveProduct(p, response, context, account));

            return response;
        }
    }
}
