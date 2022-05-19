using TrenRezervasyon.Model.ViewModel;

namespace TrenRezervasyon.Services
{
    public interface IRezervasyonService
    {
        public ResponseVM Rezervasyon(RequestVM requestVM);
    }
}
