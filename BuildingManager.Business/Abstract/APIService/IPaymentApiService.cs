using System.Threading.Tasks;
using BuildingManager.Business.PaymentApiModel;

namespace BuildingManager.Business.Abstract.APIService
{
    public interface IPaymentApiService
    {
        Task<ApiResponse<string>> CreatePayment(CreatePaymentDto createPaymentDto);
    }
}