using System;
using System.Collections.Generic;

namespace EmberAndArtimis.Models
{
    public class Category : DataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GlamorousCatPicture> CatPictures { get; set; }
        public Category()
        {
        }
    }
}
