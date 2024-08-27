using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Promo
    {
        public int PromoRightID { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public string OfferTag { get; set; }
        public string Title { get; set; }

        public List<Promo> Lista()
        {

            var lista = new List<Promo>();
            var promoDb = new Database.Promo();
            
            foreach(DataRow row in promoDb.Lista().Rows)
            {
                var promo = new Promo();
                promo.PromoRightID = Convert.ToInt32(row["PromoRightID"]);
                promo.CategoryID = Convert.ToInt32(row["CategoryID"]);
                promo.ImageURL = row["ImageURL"].ToString();
                promo.AltText = row["AltText"].ToString();
                promo.OfferTag = row["OfferTag"].ToString();
                promo.Title = row["Title"].ToString();

                lista.Add(promo);
            }
            return lista;            
        }
    }
}
