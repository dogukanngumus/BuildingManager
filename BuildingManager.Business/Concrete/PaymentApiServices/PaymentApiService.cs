using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuildingManager.Business.Abstract.APIService;
using BuildingManager.Business.PaymentApiModel;
using Newtonsoft.Json;

namespace BuildingManager.Business.Concrete.PaymentApiServices
{
    public class PaymentApiService:IPaymentApiService
    {
        private readonly HttpClient _httpClient;

        public PaymentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<string>> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            const string requestUrl = "http://localhost:4444/api/payment/createpayment";
            string requestJson = JsonConvert.SerializeObject(createPaymentDto);
            HttpResponseMessage httpResponse;
            using (var stringContent = new StringContent(requestJson,Encoding.UTF8,"application/json"))
            {
                httpResponse = await _httpClient.PostAsync(requestUrl, stringContent);
                var apiResponse = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);
            }
        }
    }
}