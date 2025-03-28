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
