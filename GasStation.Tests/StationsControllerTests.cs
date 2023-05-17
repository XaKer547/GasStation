using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Services;

namespace GasStation.Tests
{
    public class StationsControllerTests
    {
        private readonly StationsController _controller;
        private readonly Mock<IStationService> _mock;

        public StationsControllerTests()
        {
            _mock = new Mock<IStationService>();
            _controller = new StationsController(_mock.Object);
        }


        [Fact]
        public async void IndexTest()
        {
            var actionResult = await _controller.GetStationsFuelPrice("92");

            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);


            var model = okObjectResult.Value as IEnumerable<GasStationDTO>;
            Assert.NotNull(model);
        }
    }
}