using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MAUIHelpersSample.Services
{
    public class SampleService
    {
        private static HttpClient _httpClient;
        public SampleService()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri(EndPoints.RestApi) };
        }

        public async Task<List<Model.Todo>> GetTodos()
        {
            try
            {

                //GetAsync Return with Object
                var response = await _httpClient.GetAsync<List<Model.Todo>>("todos");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Value;
                }
                else
                {
                    throw new Exception(
                        $"HttpStatusCode: {response.StatusCode.ToString()} Message: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
