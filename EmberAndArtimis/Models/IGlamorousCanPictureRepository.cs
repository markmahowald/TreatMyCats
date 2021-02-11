using System;
using System.Collections;
using System.Collections.Generic;

namespace EmberAndArtimis.Models
{
    public interface IGlamorousCanPictureRepository : IGenericRepository<GlamorousCatPicture>
    {
        public IEnumerable<GlamorousCatPicture> GetAllInCategory(Category category)
        {
            throw new NotImplementedException();
        }

    }
}
