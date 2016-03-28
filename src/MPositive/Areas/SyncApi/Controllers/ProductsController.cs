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
    public class ProductsController : ApiController
    {
        public ProductsViewModel Get(int accountId)
        {
            var result = new ProductsViewModel {AccountId = accountId};
            var context = new SyncApiContext();

            // TODO handle account does not exist with a 404s
            // TODO logging
            // TODO authentication 
            var account = context.Accounts.Find(accountId);
            var products = context.Products.Where(p => p.Account.Id == account.Id).ToList();

            foreach (var product in products)
            {
                result.Products.Add(new ProductViewModel { Id = product.Id, Name = product.Name, Deleted = product.Deleted});
            }

            return result;
        }
    }
}
