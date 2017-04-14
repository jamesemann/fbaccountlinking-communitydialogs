using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebViews.Controllers
{
    public class LoginController : Controller
    {
        // GET: FakeLogin
        public ActionResult Index()
        {
            ViewBag.fbAccountLinkingToken = base.Request.Params["account_linking_token"];
            ViewBag.fbRedirectUri = base.Request.Params["redirect_uri"];
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string formRedirectUrl)
        {
            // validate password here

            // once the password is validated, generate an authorization code 
            // which is passed back to the bot conversation
            // you would typically store this in persistent store so that you
            // can associate a chatbot user with your line of business data and vice versa
            var authcode = DateTime.Now.Ticks.ToString(); 
            return Redirect($"{formRedirectUrl}&authorization_code={authcode}");
        }
    }
}