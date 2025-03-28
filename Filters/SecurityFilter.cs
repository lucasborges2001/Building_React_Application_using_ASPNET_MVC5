using System;
using System.Web.Mvc;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Controllers;

public class SecurityFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (HttpContext.Current.Session["User"] == null)
        {
            filterContext.Result = new RedirectResult("/Account/Login");
        }
    }
}


[TestClass]
public class UserControllerTests
{
    [TestMethod]
    public void Form_ReturnsView()
    {
        var controller = new UserController();
        var result = controller.Form() as ViewResult;
        Assert.IsNotNull(result);
    }
}