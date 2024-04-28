using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProjectAssessment.Models
{
    //public class InfoModel
    //{
    //}
    public class Data
    {
        public bool fullPowerMode { get; set; }
        public bool activePowerControl { get; set; }
        public int firmwareVersion { get; set; }
        public int temperature { get; set; }
        public int humidity { get; set; }

        public int version { get; set; }
        public string? messageType { get; set; }
        public bool occupancy { get; set; }
        public int stateChanged { get; set; }
    }

    public class InfoModel
    {
        public string? deviceId { get; set; }
        public string? deviceType { get; set; }
        public string? deviceName { get; set; }
        public string? groupId { get; set; }
        public string? dataType { get; set; }
        public Data data { get; set; }
        public int timestamp { get; set; }

    }

    [Table("Tbl_DataDetail")]
    public class DataDetailModel
    {
        [Key]
        public int Id { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceName { get; set; }
        public string? GroupId { get; set; }
        public string? DataType { get; set; }
        public int? Temperature { get; set; }
        public int? Humidity { get; set; }
        public bool? Occupancy { get; set; }
        public int Timestamp { get; set; }

    }


    public class OurApi_ResponseModel
    {
        public EnumRespType RespType { get; set; }
        public string RespDesp { get; set; }
    }
    public class OurApi_BaseResponseModel
    {
        public OurApi_ResponseModel Response { get; set; }
    }
    public enum EnumRespType
    {
        Success,
        Information,
        Warning,
        Error
    }

}
