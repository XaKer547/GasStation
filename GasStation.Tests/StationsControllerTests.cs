using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Services;

namespace GasStation.Tests
{
    public class StationsControllerTests
    {
        private readonly Mock<IStationService> _mock;

        public StationsControllerTests()
        {
            _mock = new Mock<IStationService>();
        }


        private readonly IEnumerable<GasStationDTO> _gasStations = new List<GasStationDTO>()
        { new(), new(), };

        [Fact]
        public async void IndexTest()
        {
            _mock.Setup(m => m.GetStationsFuelPriceByType("92").Result).Returns(_gasStations);

            var controller = new StationsController(_mock.Object);

            var actionResult = await controller.GetStationsFuelPrice("92");

            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);


            var model = okObjectResult.Value as IEnumerable<GasStationDTO>;
            Assert.NotNull(model);
        }


        [Fact]
        public async void PostTest()
        {
            var model = new CreateGasStationDTO()
            {
                Address = "ае",
                Fuels = new List<FuelDTO>
                {
                    new()
                }
            };

            _mock.Setup(m => m.CreateStation(model));

            var controller = new StationsController(_mock.Object);


            var actionResult = await controller.CreateStation(model);

            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);
        }
    }
}