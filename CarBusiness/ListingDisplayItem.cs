using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBusiness
{
    public class ListingDisplayItem
    {
        public Listing Listing { get; set; }
        public string DisplayText { get; set; }

        public ListingDisplayItem(Listing listing, string displayText)
        {
            Listing = listing;
            DisplayText = displayText;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
