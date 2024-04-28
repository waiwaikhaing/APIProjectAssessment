using APIProjectAssessment.EFDBContext;
using APIProjectAssessment.Helper;
using APIProjectAssessment.Models;

namespace APIProjectAssessment.Services
{
    public class InfoService
    {
        private readonly AppDBContext _dbContext;
        public InfoService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<int> AddInfo(AddressModel AddressModel)
        {
            var res = 0;
            try
            {
                if (AddressModel != null)
                {
                    DataDetailModel dataDetailModel = new DataDetailModel();
                    dataDetailModel.DataType = AddressModel.dataType;
                    dataDetailModel.Humidity = AddressModel.data.humidity;
                    dataDetailModel.Temperature = AddressModel.data.temperature;
                    dataDetailModel.Occupancy = AddressModel.data.occupancy;
                    dataDetailModel.DeviceId = AddressModel.deviceId;
                    dataDetailModel.DeviceName = AddressModel.deviceName;
                    dataDetailModel.GroupId = AddressModel.groupId;
                    dataDetailModel.DeviceType = AddressModel.deviceType;
                    dataDetailModel.Timestamp = AddressModel.timestamp;

                    await _dbContext.dataDetails.AddAsync(dataDetailModel);
                    res = await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                string msg = "Error :" + DateTime.Now + ">>>>" + ex.Message;
                General.WriteLogInTextFile(msg);
            }
            return res;
        }
    }
}
