using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIBINDENapplication.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ListingId { get; set; }
        public string ListingTitle { get; set; }
        public string ListingCity { get; set; }
        public decimal ListingPrice { get; set; }
        public DateTime SavedAt { get; set; }
        public string PriceFormatted => ListingPrice.ToString("N0") + " ₺";
    }
}
