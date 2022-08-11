using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkatoTestAPI.Contracts
{
	public interface IHttpClientProviderService
	{
		Task<string> GetResultAsync(string name, string phone, CancellationToken cancellationToken = default);
		Task<string> PostDataAsync<T>(string uri, T payload, CancellationToken cancellationToken = default) where T : class, new();
	}
}
