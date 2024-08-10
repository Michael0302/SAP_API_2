using MaintainGeneralizedCodeNS;

namespace QAD_WSDL_Library.Connected_Services.MaintainGeneralizedCodeNS
{
    public class Sample
    {
        public static WSDLMaintainGeneralizedCodeType MaintainGeneralizedCodePayload = new WSDLMaintainGeneralizedCodeType()
        {
            dsSessionContext =
            [
                new TtContext()
                {
                    propertyQualifier = "QAD",
                    propertyName = "Domain",
                    propertyValue = "TAIWAY"
                },
                new TtContext()
                {
                    propertyQualifier = "QAD",
                    propertyName = "Version",
                    propertyValue = "ERP3_1"
                }
            ],
            dsGeneralizedCode =
            [
                new GeneralizedCodeType(){
                    codeFldname = "test",
                    codeValue = "test",
                    codeCmmt = "test0222",
                    codeGroup = "APP"
                }
            ]
        };
    }
}
