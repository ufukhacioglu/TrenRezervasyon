using System;
using System.Collections.Generic;
using TrenRezervasyon.Model;
using TrenRezervasyon.Model.ViewModel;

namespace TrenRezervasyon.Services
{
    public class RezervasyonService : IRezervasyonService
    {
        public ResponseVM Rezervasyon(RequestVM request)
        {
            int rezervarsonKisiSayisi = request.RezervasyonYapilacakKisiSayisi;
                ICollection<YerlesimAyrinti> yerlesimPlani = new List<YerlesimAyrinti>();

            if (request.KisilerFarkliVagonlaraYerlestirilebilir == true)
            {
               

                foreach (var item in request.Tren.Vagonlar)
                {
                    var maxRezerveKoltuk = (double)(item.Kapasite * 70 / 100);
                    var rezerveEdilebilirKoltuk = Math.Floor(maxRezerveKoltuk - item.DoluKoltukAdet);

                    if (rezervarsonKisiSayisi - rezerveEdilebilirKoltuk <= 0)
                    {
                        yerlesimPlani.Add(new YerlesimAyrinti { KisiSayisi = rezervarsonKisiSayisi, VagonAdi = item.Ad });
                        ResponseVM response = new ResponseVM { RezervasyonYapilabilir = true, YerlesimAyrinti = yerlesimPlani};
                        return response;
                    }
                    else
                    {
                        yerlesimPlani.Add(new YerlesimAyrinti { KisiSayisi = (int)rezerveEdilebilirKoltuk, VagonAdi = item.Ad });
                        rezervarsonKisiSayisi -= (int)rezerveEdilebilirKoltuk; 
                    }
                }
                if (rezervarsonKisiSayisi <= 0)
                    return new ResponseVM { RezervasyonYapilabilir = true, YerlesimAyrinti = yerlesimPlani };
                else
                    return new ResponseVM { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
                
            }
            else
            {
                foreach (var item in request.Tren.Vagonlar)
                {
                    var vagonYuzde = 100 * (item.DoluKoltukAdet + rezervarsonKisiSayisi) / item.Kapasite;
                    if (vagonYuzde <= 70)
                    {
                        yerlesimPlani.Add(new YerlesimAyrinti { KisiSayisi = rezervarsonKisiSayisi, VagonAdi = item.Ad });
                        ResponseVM response = new() { RezervasyonYapilabilir = true, YerlesimAyrinti = yerlesimPlani };
                        return response;
                    }

                }

                return new ResponseVM { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }

            
        }
    }
}
