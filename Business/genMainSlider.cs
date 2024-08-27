using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class genMainSlider
    {
        public int MainSliderID { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public string OfferTag { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnText { get; set; }
        public Nullable<bool> isDeleted { get; set; }


        public List<genMainSlider> Lista()
        {

            var lista = new List<genMainSlider>();
            var sliderDb = new Database.Slider();
            
            foreach(DataRow row in sliderDb.Lista().Rows)
            {
                var slide = new genMainSlider();
                slide.MainSliderID = Convert.ToInt32(row["MainSliderID"]);
                slide.ImageURL = row["ImageURL"].ToString();
                slide.AltText = row["AltText"].ToString();
                slide.OfferTag = row["OfferTag"].ToString();
                slide.Description = row["Description"].ToString();
                slide.BtnText = row["BtnText"].ToString();
                

                lista.Add(slide);
            }
            return lista;            
        }
    }
}
