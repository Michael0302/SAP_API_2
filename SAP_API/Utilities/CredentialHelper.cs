using DotnetSdkUtilities.ObjectExtensions;
using Microsoft.Extensions.Options;
using SAP_API.Configuration;
using System.Reflection;

namespace SAP_API.Utilities
{
    public class CredentialHelper
    {
        public static (string UserName, string Password) GetCredentials(IOptionsMonitor<Settings> _setting, string? clientCredentialOption)
        {
            if (!string.IsNullOrEmpty(clientCredentialOption) && _setting.CurrentValue.SAP.HasProperty(clientCredentialOption))
            {
                Type sapType = _setting.CurrentValue.SAP.GetType();

#pragma warning disable CS8600, CS8602, CS8619
                PropertyInfo clientCredentialProperty = sapType.GetProperty(clientCredentialOption);

                object clientCredentialValue = clientCredentialProperty.GetValue(_setting.CurrentValue.SAP);
                Type clientCredentialType = clientCredentialValue.GetType();

                PropertyInfo userNameProperty = clientCredentialType.GetProperty("UserName");
                PropertyInfo passwordProperty = clientCredentialType.GetProperty("Password");
                string userName = (string)userNameProperty.GetValue(clientCredentialValue);
                string password = (string)passwordProperty.GetValue(clientCredentialValue);

                return (userName, password);
            }
#pragma warning restore CS8600, CS8602, CS8619

            return (_setting.CurrentValue.SAP.ClientCredentials.UserName, _setting.CurrentValue.SAP.ClientCredentials.Password);
        }
    }
}
