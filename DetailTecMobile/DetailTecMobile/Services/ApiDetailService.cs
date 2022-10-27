using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DetailTecMobile.Services
{
    public class ApiDetailService
    {
        private readonly HttpClient _httpClient;

        public ApiDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
