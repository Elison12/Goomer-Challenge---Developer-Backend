using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Notification.ValueObjects
{
    public abstract class ValueObject
    {
        public ValueObject()
        {
            IsValid = true;
        }
        public bool IsValid { get; private set; }
        public Errors Errors { get; private set; }
        protected void AddNotification(Errors errors)
        {
            IsValid = false;
            Errors = errors;
        }
    }
}
