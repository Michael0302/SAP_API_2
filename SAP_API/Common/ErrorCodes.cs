namespace SAP_API.Common
{
    public enum ErrorCodes
    {
        InternalServerError = 1050000,
        InternalServerErrorSAPError = 1050000,
        NotFound = 1040400,
        BadRequest = 1040000,
        BadRequestKeyNotFound = 1040001,
        BadRequestInvalidData = 1040002,
        Unauthorized = 1040100,
        UnauthorizedKeyInvalid = 1040101,
        Forbidden = 1040300,
    }
}
