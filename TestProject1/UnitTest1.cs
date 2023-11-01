using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using TestContext = Bunit.TestContext;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private TestContext ctx;
        private IRenderedComponent<KP_ManageUsers.Client.Pages.Index> indexComponent;

        [SetUp]
        public void Setup()
        {
            ctx = new TestContext();
            indexComponent = ctx.RenderComponent<KP_ManageUsers.Client.Pages.Index>();
        }

        [Test]
        public void AddUser_Click_ShouldDisplayUserPopup()
        {
            // Act: Simulate a click on the "Add User" button
            indexComponent.Find("button[onclick^=AddUser_Click]").Click();

            // Assert: Check if the user popup is displayed
            Assert.IsTrue(indexComponent.Markup.Contains("div.modal[style*='display:block;']"));
        }


        [Test]
        public void SaveUser_Click_WithIncompleteData_ShouldShowErrorMessage()
        {
            // This test checks that an error message is shown when saving with incomplete data
            indexComponent.Find("button[onclick^=SaveUser_Click]").Click();

            // Assert that the error message is displayed
            Assert.That(indexComponent.Find("p[style*='color: red;']").TextContent, Is.Not.Empty);
        }
    }
}