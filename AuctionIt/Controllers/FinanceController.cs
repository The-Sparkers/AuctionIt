using AuctionIt.Common;
using AuctionIt.PayPal;
using PayPal.Api;
using System.Web.Mvc;

namespace AuctionIt.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        public ActionResult Index()
        {
            ViewBag.Balance = 1000;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> TopUp(decimal amount)
        {
            var task = Functions.PKRToUSDAsync(amount);
            var amountInUsd = await task;
            ViewBag.Value = amountInUsd;
            return View();
        }
        public ActionResult TopUp(decimal amount, bool? fromForm)
        {
            ViewBag.Value = amount;
            return View();
        }
        [HttpPost]
        public void ConfirmPaypalTransaction(string orderID)
        {
            Order order = Order.Get(Configuration.GetAPIContext(), orderID);
            var amount = order.amount;
        }
    }
}