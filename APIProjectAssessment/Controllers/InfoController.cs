using APIProjectAssessment.EFDBContext;
using APIProjectAssessment.Helper;
using APIProjectAssessment.Models;
using APIProjectAssessment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIProjectAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public InfoController(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddData(InfoModel infoModel)
        {

            OurApi_BaseResponseModel model = new OurApi_BaseResponseModel();
            try
            {
                InfoService _service = new InfoService(_dbContext);

                var payloadJson = JsonConvert.SerializeObject(infoModel);
                string msg = "Received Payload :" + DateTime.Now + ">>>>" + payloadJson;
                General.WriteLogInTextFile(msg);

                var item = await _service.AddInfo(infoModel);
                if (item == 0)
                {
                    model.Response = new OurApi_ResponseModel
                    {
                        RespType = EnumRespType.Information,
                        RespDesp = "Saving Failed."
                    };
                    goto result;
                }
                model.Response = new OurApi_ResponseModel
                {
                    RespType = EnumRespType.Success,
                    RespDesp = "Saving Success."
                };
            }
            catch (Exception ex)
            {
                string msg = "Error :" + DateTime.Now + ">>>>" + ex.Message;
                General.WriteLogInTextFile(msg);
            }

        result:
            return Ok(model);
        }
    }
}
