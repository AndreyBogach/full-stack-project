using api.Helpers;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("VueCorsPolicy")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var senderService = new MessageSender();
            var data = senderService.ReadAllSMS(string.Empty);

            if (data == null)
                return this.Ok();
            
            return this.Ok(data);
        }
        
        [HttpGet("{date}")]
        public IActionResult Get(string date)
        {
            var senderService = new MessageSender();
            var data = senderService.ReadAllSMS(date);

            if (data == null)
                return this.Ok();

            return this.Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SmsRequest data)
        {
            var senderService = new MessageSender();
            var result = senderService.SendSMS(data.Number, data.Content);

            return this.Ok(result);
        }
    }
}