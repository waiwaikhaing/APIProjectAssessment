using APIProjectAssessment.EFDBContext;
using APIProjectAssessment.Helper;
using APIProjectAssessment.Models;
using APIProjectAssessment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjectAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public AddressController(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        [HttpPost]
        public async Task<IActionResult> StoreAddressLocation(string addr)
        {
            OurApi_BaseResponseModel model = new OurApi_BaseResponseModel();
            try
            {
                int item = 0;
                AddressService _service = new AddressService(_dbContext);
                AddressLocationModel addressModel = new AddressLocationModel();
                if (addr != null)
                {
                    var beforeIndexValue = "";
                    string[] parts = addr.Split(new string[] { " - " }, StringSplitOptions.None);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        addressModel.Name = parts[i];
                        if (i == 0)  beforeIndexValue = ""; 
                        else beforeIndexValue = parts[i - 1];
                         item = await _service.AddAddress(addressModel, beforeIndexValue);
                    }
                }
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
