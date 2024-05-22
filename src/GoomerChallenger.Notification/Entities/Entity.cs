using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Notification.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Isvalid { get; private set; }
        public Errors Errors { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            Errors = new Errors();
            Isvalid = true;
        }

        protected void AddNotification(Errors errors)
        {
            Isvalid = false;
            Errors = errors;
        }
    }
}
