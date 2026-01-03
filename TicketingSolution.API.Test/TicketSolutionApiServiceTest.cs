using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using TicketingSolution.API.Controllers;
using Moq;
using Shouldly;


namespace TicketingSolution.API.Test
{
    public class TicketSolutionApiServiceTest
    {
        [Fact]
        public void Should_Return_Forcast_Results()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            //Act
            var result = controller.Get();

            //Assert
            result.Count().ShouldBeGreaterThan(1);
            result.ShouldNotBeNull();

        }
    }
}
