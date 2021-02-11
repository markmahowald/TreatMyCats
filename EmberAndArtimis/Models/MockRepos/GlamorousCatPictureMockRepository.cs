using System;
using System.Collections.Generic;
using System.Linq;

namespace EmberAndArtimis.Models.MockRepos
{
    /*This mock repo was written to mirror the real repository as closelsy as possible.  
     * Unfortunately it could not be generic because we needed to mock up specific object types.
    */
    public class GlamorousCatPictureMockRepository : IGenericRepository<GlamorousCatPicture>
    {
        public List<GlamorousCatPicture> MockedUpCatPictures { get; set; }

        public GlamorousCatPictureMockRepository(int numberOfMocks)
        {
            MockupSomeData(numberOfMocks);
        }

        private void MockupSomeData(int numberOfMocks)
        {
            if(this.MockedUpCatPictures is null)
            {
                this.MockedUpCatPictures = new List<GlamorousCatPicture>();
            }
            this.MockedUpCatPictures = new List<GlamorousCatPicture>();
            for (int i = 0; i < numberOfMocks; i++)
            {
                GlamorousCatPicture pic = new GlamorousCatPicture()
                {
                    Id = i,
                    Name = $"GlamorousCatPic{i}",
                    Description = $"Mocked up catPicture number{i}",
                    CategoryId = (i%3)
                };
                this.MockedUpCatPictures.Add(pic);

            }
        }

        private void PlaceInCategory(List<GlamorousCatPicture> pics, CategoryMockRepository categoryRepo)
        {
            List<Category> allCatagories = categoryRepo.GetAll().ToList();
            for (int i = 0; i < pics.Count; i++)
            {
                pics[i].Category = allCatagories[allCatagories.Count % (i + 1)];
            }

        }

        public GlamorousCatPictureMockRepository()
        {
            this.MockupSomeData(15);

        }
        public IEnumerable<GlamorousCatPicture> GetAll()
        {
            return this.MockedUpCatPictures;
        }
        public GlamorousCatPicture Create(GlamorousCatPicture item)
        {
            this.MockedUpCatPictures.Add(item);
            item.Id = this.MockedUpCatPictures.Select(pic => pic.Id).ToList().Max() + 1;
            return item;
        }

        public bool Delete(int id)
        {
            GlamorousCatPicture picToRemove = this.MockedUpCatPictures.FirstOrDefault(pic => pic.Id == id);
            if (picToRemove!=null)
            {
                this.MockedUpCatPictures.Remove(picToRemove);
            }

            return (picToRemove ==null? false: true);
        }

        public GlamorousCatPicture GetById(int id)
        {
            return this.MockedUpCatPictures.FirstOrDefault(pic => pic.Id == id);
        }

        public GlamorousCatPicture Update(int id, GlamorousCatPicture item)
        {
            GlamorousCatPicture picToUpdate = this.MockedUpCatPictures.FirstOrDefault(pic => pic.Id == id);

            if (picToUpdate == null)
            {
                throw new Exception("No Glamorous Cat Picture with that ID could be located. ");
            }
            picToUpdate.Name = item.Name;
            picToUpdate.Category = item.Category;
            picToUpdate.Description = item.Description;

            return picToUpdate;
        }
    }
}
