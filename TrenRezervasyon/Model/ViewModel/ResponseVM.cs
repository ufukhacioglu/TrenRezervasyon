using System.Collections.Generic;

namespace TrenRezervasyon.Model.ViewModel
{
    public class ResponseVM
    {
        public bool RezervasyonYapilabilir { get; set; }
        public ICollection<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
