using System;
namespace EmberAndArtimis.Models
{
    public class GlamorousCatPicture : DataObject
    {

        public string Name { get; set; }
        public string RelativePath { get; set; }
        public string Description { get; set; }

        //to fit with a tutorial I am adding a category
        public Category Category { get; set; }

        public GlamorousCatPicture()
        {
            
        }
    }
}
