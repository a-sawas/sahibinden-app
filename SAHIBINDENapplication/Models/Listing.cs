using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIBINDENapplication.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OwnerName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CoverImagePath { get; set; }

        public string PriceFormatted => Price.ToString("N0") + " ₺";

        public string TimeAgo
        {
            get
            {
                var diff = DateTime.Now - CreatedAt;
                if (diff.TotalMinutes < 1) return "Just now";
                if (diff.TotalHours < 1) return $"{(int)diff.TotalMinutes} min ago";
                if (diff.TotalDays < 1) return $"{(int)diff.TotalHours} hours ago";
                if (diff.TotalDays < 30) return $"{(int)diff.TotalDays} days ago";
                if (diff.TotalDays < 365) return $"{(int)(diff.TotalDays / 30)} months ago";
                return $"{(int)(diff.TotalDays / 365)} years ago";
            }
        }

        public bool IsOwnedBy(int userId) => UserId == userId;
        public override string ToString() => Title;
    }
}
