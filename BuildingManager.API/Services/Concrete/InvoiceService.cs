using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.API.Configurations;
using BuildingManager.API.Entities;
using BuildingManager.API.Services.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BuildingManager.API.Services.Concrete
{
    public class InvoiceService:IInvoiceService
    {
        private IMongoCollection<InvoicePayment> _invoicePaymentCollection;
        private BuildingManagerPaymentConfiguration _config;

        public InvoiceService(IOptions<BuildingManagerPaymentConfiguration> config)
        {
            _config = config.Value;
            MongoClient client = new MongoClient(_config.ConnectionString);
            IMongoDatabase db = client.GetDatabase(_config.DbName);
            _invoicePaymentCollection = db.GetCollection<InvoicePayment>(_config.InvoicePaymentCollection);
        }

        public async Task<List<InvoicePayment>> GetAll()
        {
            return await _invoicePaymentCollection.Find(i=>true).ToListAsync();
        }

        public async Task<InvoicePayment> GetById(string id)
        {
            return await _invoicePaymentCollection.Find(i=>i.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(InvoicePayment invoicePayment)
        {
            await _invoicePaymentCollection.InsertOneAsync(invoicePayment);
        }

        public async Task Delete(string id)
        {
            await _invoicePaymentCollection.DeleteOneAsync(i=>i.Id == id);
        }
    }
}