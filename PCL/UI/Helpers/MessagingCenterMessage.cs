using System;

namespace PCL.UI.Helpers
{
    public class MessagingCenterMessage
    {
        public String Key { get; set; }

        public Object Value { get; set; }

        public MessagingCenterMessage(String key, Object value = null)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}