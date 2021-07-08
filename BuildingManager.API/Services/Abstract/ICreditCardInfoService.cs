using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.API.Dtos;
using BuildingManager.API.Entities;

namespace BuildingManager.API.Services.Abstract
{
    public interface ICreditCardInfoService
    {
        Task<List<CreditCardInfo>> GetAllAsync();
        Task<CreditCardInfo> GetById(string id);
        Task<CreditCardInfo> GetByFilter(InvoicePaymentDto filter);
        Task Add(CreditCardInfo creditCardInfo);
        Task Delete(string id);
        Task Update(string id, CreditCardInfo creditCardInfo);
    }
}