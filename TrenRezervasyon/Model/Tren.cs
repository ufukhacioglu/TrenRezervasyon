using System.Collections.Generic;

namespace TrenRezervasyon.Model
{
    public class Tren : Base
    {
        public ICollection<Vagon> Vagonlar { get; set; }
    }
}
