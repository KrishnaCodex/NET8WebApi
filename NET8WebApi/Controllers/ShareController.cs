using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NET8WebApi.Models;
using NET8WebApi.Services;

namespace NET8WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IShare _shareService;

       
        public ShareController(IShare shareService)
        {
            _shareService = shareService;
        }

        [Authorize]
        [HttpGet("GetAllShares")]
        public ActionResult<List<Share>> Get()
        {
            var shares = _shareService.GetData();
            return Ok(shares);  
        }

        
        [HttpGet("GetShareById{id}")]
        public ActionResult<Share> Getwithid(int id)
        {
            var share = _shareService.GetDataWithId(id);
            if (share == null)
            {
                return NotFound(); 
            }
            return Ok(share);
        }

        
        [HttpGet("GetShareByfilter/{st}")]
        public ActionResult<List<Share>> Getfilter(string st)
        {
            var filteredShares = _shareService.GetDataWithFilter(st);
            return Ok(filteredShares);  
        }

        
        [HttpPost("NewShare")]
        public ActionResult<Share> Post(Share value)
        {
            var createdShare = _shareService.PostData(value);
            return Ok(createdShare);
        }

        
        [HttpDelete("DeleteShare{id}")]
        public ActionResult Delete(int id)
        {
            var success = _shareService.DeleteData(id);
            if (success==null)
            {
                return NotFound(); 
            }
            return Ok(success);
        }
    }
}
