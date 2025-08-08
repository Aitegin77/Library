namespace DAL.Services
{
    public static class CountryService
    {
        public static async Task<HttpResponseMessage> GetCountriesAsync()
        {
            using var httpClient = new HttpClient();

            return await httpClient.GetAsync("https://restcountries.com/v3.1/all");

            // Private key
            /*httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "pzAvPULz7mxOgAuRUjNNzZNezBMfMD");

            httpClient.DefaultRequestHeaders.Add("Accept-Language", "ru");*/

            //return await httpClient.GetAsync("https://data-api.oxilor.com/rest/countries");
        }
    }
}
