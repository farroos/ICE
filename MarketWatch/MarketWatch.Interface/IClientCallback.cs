using System.ServiceModel;

namespace MarketWatch.Interface
{
    [ServiceContract]
    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyPriceChange(string symbol, decimal price);
    }
}