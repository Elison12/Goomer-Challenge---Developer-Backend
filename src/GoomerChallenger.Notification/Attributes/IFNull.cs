using System.ComponentModel.DataAnnotations;

namespace GoomerChallenger.Notification.Attributes
{
    public class IfNullAttribute : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return ErrorMessage;
        }
    }
}
