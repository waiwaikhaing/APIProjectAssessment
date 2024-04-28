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

        public async Task<int> AddInfo(InfoModel infoModel)
        {
            var res = 0;
            try
            {
                if (infoModel != null)
                {
                    DataDetailModel dataDetailModel = new DataDetailModel();
                    dataDetailModel.DataType = infoModel.dataType;
                    dataDetailModel.Humidity = infoModel.data.humidity;
                    dataDetailModel.Temperature = infoModel.data.temperature;
                    dataDetailModel.Occupancy = infoModel.data.occupancy;
                    dataDetailModel.DeviceId = infoModel.deviceId;
                    dataDetailModel.DeviceName = infoModel.deviceName;
                    dataDetailModel.GroupId = infoModel.groupId;
                    dataDetailModel.DeviceType = infoModel.deviceType;
                    dataDetailModel.Timestamp = infoModel.timestamp;

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
