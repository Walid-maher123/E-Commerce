using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public interface IResponseCachService
    {
        Task CachData(string Key, object Response, TimeSpan timeSpan);

        Task<string?> GetCachedData(string Key);
    }
}
