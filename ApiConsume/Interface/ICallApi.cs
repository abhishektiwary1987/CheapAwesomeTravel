using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume
{
    public interface ICallApi
    {
        Task<string> FetchHotelAsync(int destinationId, int nights, string SecretAuthCode, string ApiUrl);
    }
}
