using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.API.Dtos;
using BuildingManager.API.Entities;

namespace BuildingManager.API.Services.Abstract
{
    public interface IInvoiceService
    {
        Task<List<InvoicePayment>> GetAll();
        Task<InvoicePayment> GetById(string id);
        Task Add(InvoicePayment invoicePayment);
        Task Delete(string id);
    }
}