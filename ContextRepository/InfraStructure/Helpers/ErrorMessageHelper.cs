using System.Text;

namespace ContextRepository.InfraStructure.Helpers
{
    public static class ErrorMessageHelper
    {
        public static string GetSwitchCaseValueNotSupportedMessage(string context, object value)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Context: {0} => Value: {1} does not supported.", context, value);

            return sb.ToString();
        }
    }
}
