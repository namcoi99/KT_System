using KT_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KT_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionController : Controller
    {

        private readonly IConfiguration _config;
        public TransactionController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index(DateTime? FromDate)
        {
            var txViewModel = new TransactionViewModel
            {
                Transactions = Enumerable.Empty<Transaction>()
            };

            if (FromDate.HasValue)
            {
                using var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(_config["HISCloud:Uri"]);
                httpClient.DefaultRequestHeaders.Add("Authorization", _config["HISCloud:Authorization"]);
                var responseTask = httpClient.GetAsync("ketoan_amaz-giaodich?from=" + ((DateTimeOffset)FromDate).ToUnixTimeSeconds());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    readJob.Wait();
                    //transactions = readJob.Result;
                    ResultModel resultResponse = JsonConvert.DeserializeObject<ResultModel>(readJob.Result);
                    txViewModel.Transactions = resultResponse.Result;
                }
                else
                {
                    txViewModel.Transactions = Enumerable.Empty<Transaction>();
                    ModelState.AddModelError(string.Empty, "Server error occured!!!");
                }
            }
            return View(txViewModel);
        }
    }
}
