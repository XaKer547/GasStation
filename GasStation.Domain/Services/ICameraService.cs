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

//https://social.msdn.microsoft.com/Forums/vstudio/en-US/0bc05a01-9eab-4866-bb7d-1e5d22a56f5c/how-i-can-make-possible-data-sharing-between-two-wpf-applications-through-internet?forum=wpf