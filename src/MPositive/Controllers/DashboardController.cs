using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using MPositive.DAL;
using MPositive.Models;

namespace MPositive.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index(int accountId)
        {
            var context = new SyncApiContext();

            var account = context.Accounts.Find(accountId);
            if (account == null)
                return new HttpNotFoundResult("No Account with id "  + accountId);

            var products = context.Products.Where(p => p.Account.Id == account.Id).ToList();

            var viewModel = new DashboardViewModel() { AccountId = accountId, Products = products };
            return View(viewModel);
        }
	}

    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Products = new List<ProductModel>();
        }
        public int AccountId { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}