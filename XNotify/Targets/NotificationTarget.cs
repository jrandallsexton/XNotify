
using XNotify.Contracts;

namespace XNotify.Targets
{
    public class NotificationTarget : INotificationTarget
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public bool SendEmail { get; set; }
        public bool SendSms { get; set; }

        public NotificationTarget(string name, string email, string sms, bool sendEmail, bool sendSms)
        {
            this.Name = name;
            this.Email = email;
            this.Sms = sms;
            this.SendEmail = sendEmail;
            this.SendSms = sendSms;
        }
    }
}