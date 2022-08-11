using Microsoft.AspNetCore.Mvc;
using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Domain;

namespace WorkatoTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkatoAPIRecipeController : ControllerBase
    {
      
        private readonly ILogger<WorkatoAPIRecipeController> _logger;
        private readonly WorkatoApiOptions _workatoApiOptions;
        private readonly IHttpClientProviderService _httpClientProviderService;
        public WorkatoAPIRecipeController(ILogger<WorkatoAPIRecipeController> logger, WorkatoApiOptions workatoApiOptions, IHttpClientProviderService httpClientProviderService)
        {
            _logger = logger;
            _workatoApiOptions = workatoApiOptions;
            _httpClientProviderService = httpClientProviderService;
        }

        [HttpGet(Name = "CallWorkatoRecipe")]
        public  async Task<IActionResult> CreateSeller(string SellerName, string Phone)
        {
            try
            {
                var result = await _httpClientProviderService.GetResultAsync(SellerName, Phone);
                //
                return Ok(result);
            }
            catch(Exception ex)
			{
                return BadRequest(ex.Message);
			}
        }
    }
}