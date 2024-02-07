using LR2TIS.Controllers;
using LR2TIS.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Models;

namespace UsersTests
{
    public class HomeControllerTests
    {
        private readonly Mock<IRepository> _mockRepo;
        private readonly HomeController _controller;
        public HomeControllerTests()
        {
            _mockRepo = new Mock<IRepository>();
            _controller = new HomeController(_mockRepo.Object);
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, Name="Tom", Email="Tom@mail.ru", Phone="89993745632",Age=35},
                new User { Id=2, Name="Alice",Email="Alice@mail.ru", Phone="89993745632",Age=29},
            };
            return users;
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfUsers()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var controller = new HomeController(mock.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            Assert.Equal(GetTestUsers().Count, model.Count());
        }
        [Fact]
        public void CreateUse_InvalidModelState_ReturnsViewResultWithUserModel()
        {
            var mock = new Mock<IRepository>();
            var controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            User newUser = new User();
            var result = controller.CreateUser(newUser);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(newUser, viewResult?.Model);
        }
        [Fact]
        public void GetUser_ActionExecutes_ReturnsNotFoundResultWhenUserNotFound()
        {
            int testUserId = 5;
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.Get(testUserId)).Returns(null as User);
            var controller = new HomeController(mock.Object);
            var result = controller.GetUser(testUserId);
            Assert.IsType<NotFoundResult>(result);
        }



    }
}
