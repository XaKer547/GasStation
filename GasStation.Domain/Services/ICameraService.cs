using System.ServiceModel;

namespace GasStation.Domain.Services
{
    [ServiceContract]
    public interface ICameraService
    {
        [OperationContract]
        string GetCar(string carNumber);
    }
}
