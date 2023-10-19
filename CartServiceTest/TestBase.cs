using Application.ServiceInterfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace CartServiceTest
{
    public class TestBase
    {
        public CartController cartController;

        public TestBase()
        {
            var loggerMock = new Mock<ILogger<CartController>>();
            var serviceManagerMock = new Mock<IServiceManager>();

            cartController = new CartController(serviceManagerMock.Object, loggerMock.Object);
        }
    }
}
