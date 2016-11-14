using System;

namespace ContextRepository.InfraStructure.Helpers
{
    public static class ExceptionHelper
    {
        public static NotSupportedException SwitchCaseValueNotSupportedException(string context, object value, Exception innerException = null)
        {
            return new NotSupportedException(ErrorMessageHelper.GetSwitchCaseValueNotSupportedMessage(context, value), innerException);
        }
    }
}
