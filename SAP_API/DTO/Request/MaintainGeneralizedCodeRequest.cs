using MaintainGeneralizedCodeNS;

namespace SAP_API.DTO.Request
{
    public class MaintainGeneralizedCodeRequest
    {
        public required WSDLMaintainGeneralizedCodeType Payload { get; set; }
        public required MaintainGeneralizedCodeRequestHeader Header { get; set; }
        public string? User { get; set; }
    }
    public class MaintainGeneralizedCodeRequestHeader
    {
        public required string Action { get; set; }
        public required string To { get; set; }
        public required string MessageID { get; set; }
        public required ReferenceParametersType ReferenceParameters { get; set; }
        public required ReplyToType ReplyTo { get; set; }
    }
    public class MaintainGeneralizedCodeRequestHeaderSample
    {
        public static MaintainGeneralizedCodeRequestHeader Header = new()
        {
            Action = "?",
            To = "QADERP",
            MessageID = "?",
            ReferenceParameters = new ReferenceParametersType()
            {
                suppressResponseDetail = false,
            },
            ReplyTo = new ReplyToType()
            {
                Address = "QADERP",
            }
        };
    }
}
