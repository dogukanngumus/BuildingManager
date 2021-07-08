using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.API.Configurations;
using BuildingManager.API.Dtos;
using BuildingManager.API.Entities;
using BuildingManager.API.Services.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BuildingManager.API.Services.Concrete
{
    public class CreditCardInfoService:ICreditCardInfoService
    {
        private IMongoCollection<CreditCardInfo> _creditCardPaymentCollection;
        private BuildingManagerPaymentConfiguration _config;

        public CreditCardInfoService(IOptions<BuildingManagerPaymentConfiguration> config)
        {
            _config = config.Value;
            MongoClient client = new MongoClient(_config.ConnectionString);
            IMongoDatabase db = client.GetDatabase(_config.DbName);
            _creditCardPaymentCollection = db.GetCollection<CreditCardInfo>(_config.CreditCardInfoCollection);
        }

        public async Task<List<CreditCardInfo>> GetAllAsync()
        {
            return await _creditCardPaymentCollection.Find(i=>true).ToListAsync();
        }

        public async Task<CreditCardInfo> GetById(string id)
        {
            return await _creditCardPaymentCollection.Find(i=>i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<CreditCardInfo> GetByFilter(InvoicePaymentDto filter)
        {
            return await _creditCardPaymentCollection.Find(x=>x.CardNumber == filter.CardNumber &&
                                                              x.Owner == filter.Owner &&
                                                              x.Cvv == filter.Cvv &&
                                                              x.ValidMonth == filter.ValidMonth &&
                                                              x.ValidYear == filter.ValidYear).FirstOrDefaultAsync();
        }

        public async Task Add(CreditCardInfo creditCardInfo)
        {
            await _creditCardPaymentCollection.InsertOneAsync(creditCardInfo);
        }

        public async Task Delete(string id)
        {
            await _creditCardPaymentCollection.DeleteOneAsync(i=>i.Id == id);
        }

        public async Task Update(string id, CreditCardInfo creditCardInfo)
        {
            await _creditCardPaymentCollection.ReplaceOneAsync(x => x.Id == id, creditCardInfo);
        }
    }
}