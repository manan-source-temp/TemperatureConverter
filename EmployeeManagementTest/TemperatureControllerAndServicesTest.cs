using EmployeManagementDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TemperatureConverter.BLL;
using Xunit;

namespace EmployeeManagementTest
{
    public class TemperatureControllerAndServicesTest
    {        
        public Mock<ITemperatureService> mock = new Mock<ITemperatureService>();
        TemperatureController temperatureController;
        //API Test
        [Fact]        
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
       
            mock.Setup(p => p.TemperatureConverter(1,"f","c")).ReturnsAsync(12.222222222222223);
            temperatureController = new TemperatureController(mock.Object);            
            var result = await temperatureController.Get(1, "f", "c");
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task Get_BadRequest_ReturnsTemperatureConverterNull()
        {
            temperatureController = new TemperatureController(mock.Object);
            var result = await temperatureController.Get(1, "", "");
            var ex = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Temperature converter type cannot same", ex.Value);
        }

        //Business Test
        [Fact]
        public async Task TemperatureConverter_WhenCalled_ReturnsTemperature()
        {            
            var temperatureService = new TemperatureService();
            var res = await temperatureService.TemperatureConverter(1, "f", "c");
            Assert.Equal("-17.2222222222222", res.ToString());
            
        }

        [Fact]
        public async Task TemperatureConverter_WhenCalled_ReturnsTemperatureConverterNull()
        {
            var temperatureService = new TemperatureService();
            var res = await temperatureService.TemperatureConverter(1, "", "c");
            Assert.Equal("1", res.ToString());
        }

    }
}
