using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.PaymentApiModel;

namespace BuildingManager.Business.Abstract.APIService
{
    public interface ICreditCardInfoApiService
    {
        Task<List<GetCreditCardDto>> GetAll();
    }
}