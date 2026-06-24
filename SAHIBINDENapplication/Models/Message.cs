using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIBINDENapplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public int ListingId { get; set; }
        public string ListingTitle { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }

        public string BodyPreview => Body?.Length > 60 ? Body.Substring(0, 60) + "…" : Body;
        public string TimeLabel => SentAt.Date == DateTime.Today
            ? SentAt.ToString("HH:mm")
            : SentAt.ToString("dd MMM");

        public override string ToString() => $"{SenderName}: {BodyPreview}";
    }

}
