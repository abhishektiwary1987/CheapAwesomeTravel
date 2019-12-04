using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using ApiConsume;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class CheapAwesomeTrvlController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _Logger;
        private readonly  ICallApi _ApiCall;
        public CheapAwesomeTrvlController(IConfiguration config, ILogger<CheapAwesomeTrvlController> Logger, ICallApi ApiCall)
        {
            _config = config;
            _Logger = Logger;
            _ApiCall = ApiCall;
        }
        public IActionResult index()
        {
            return View();
        }

        public async Task<JsonResult> fetchHotelDetails(int destinationId, int noofnights)
        {  
            try
            {
                string SecretAuthCode = _config.GetSection("SecretAuthCode").Value;
                string[] _RateType = _config.GetSection("RateType").Value.Split(",");
                string ClientURL = _config.GetSection("ClientURL").Value;

                String strReadTask = await _ApiCall.FetchHotelAsync(destinationId, noofnights, SecretAuthCode, ClientURL);
                LogUtility.WriteLog(strReadTask);
                _Logger.LogInformation(strReadTask);
                var readTask = JsonConvert.DeserializeObject<IEnumerable<HotelMainModule>>(strReadTask);

                var hotellst = readTask.Select(x => new
                {
                    HotelName = x.hotel.name,
                    RateType = x.rates.Select(y => y.rateType),
                    Value = x.rates.Select(y => y.value),
                    BoardType = x.rates.Select(y => y.boardType),
                    Rate = (x.rates.Select(y => y.rateType == _RateType[0] ? Math.Round((y.value * noofnights), 2) : Math.Round(y.value, 2)))
                }).ToList();
                return Json(hotellst);

            }
            catch(Exception ex)
            {
                LogUtility.GlobalErrorLog(ex.Message);
                return Json(null);
            } 
            //}
        }
    }
}
