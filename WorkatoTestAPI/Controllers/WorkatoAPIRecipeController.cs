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
        private readonly IWorkatoService _workatoService;
       
        public WorkatoAPIRecipeController(ILogger<WorkatoAPIRecipeController> logger, IWorkatoService workatoService)
        {
            _logger = logger;
            _workatoService = workatoService;
        }

        [HttpGet(Name = "CallWorkatoRecipeTest")]
        public async Task<IActionResult> CreateSellerTest(string name,string phone)
        {
            try
            {
                var result = await _workatoService.CreateSellerAsync(name,phone);
                //
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "CreateSeller")]
        public  async Task<IActionResult> CreateSeller(SellerDTO sellerDTO)
        {
            try
            {
                var result = await _workatoService.CreateSellerAsync(sellerDTO);
                //
                return Ok(result);
            }
            catch(Exception ex)
			{
                return BadRequest(ex.Message);
			}
        }

        [HttpPost(Name = "UpdateSeller")]
        public async Task<IActionResult> UpdateSeller(SellerDTO sellerDTO)
        {
            try
            {
                await _workatoService.UpdateSellerAsync(sellerDTO);
                //
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}