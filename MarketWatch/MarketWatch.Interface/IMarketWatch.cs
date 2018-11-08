using System.ServiceModel;

namespace MarketWatch.Interface
{
    [ServiceContract(SessionMode = SessionMode.Allowed,
        CallbackContract = typeof(IClientCallback))]
    public interface IMarketWatch
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = true)]
        void PublishPriceChange(string symbol, decimal newPrice);
    }
}