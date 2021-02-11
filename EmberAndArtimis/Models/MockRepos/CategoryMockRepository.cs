using System;
using System.Collections.Generic;
using System.Linq;

namespace EmberAndArtimis.Models.MockRepos
{
    public class CategoryMockRepository : IGenericRepository<Category>
    {
        public List<Category> MockedUpCategories { get; set; }
        public CategoryMockRepository(int numberOfMocks)
        {
            this.MockedUpCategories = new List<Category>();
            MockupSomeData(numberOfMocks);
        }

        private void MockupSomeData(int numberOfMocks)
        {
            if (this.MockedUpCategories == null)
            {
                this.MockedUpCategories = new List<Category>();
            }
            for (int i = 0; i < numberOfMocks; i++)
            {
                this.MockedUpCategories.Add(
                    new Category()
                    {
                        Id = i,
                        Name = $"Category{i}",
                        Description = $"Mocked up Cagetory number {i}"
                    });

            }
        }

        public CategoryMockRepository()
        {

            this.MockupSomeData(5);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.MockedUpCategories;
        }

        public Category Create(Category item)
        {
            this.MockedUpCategories.Add(item);
            item.Id = this.MockedUpCategories.Select(cat => cat.Id).Max() + 1;
                return item;
        }

        public bool Delete(int id)
        {
            bool success = false;
            Category catToRemove = this.MockedUpCategories.FirstOrDefault(cat => cat.Id == id);
            if (catToRemove is not null)
            {
                this.MockedUpCategories.Remove(catToRemove);
                success = true;
            }
            return success;
        }

        public Category GetById(int id)
        {
            return this.MockedUpCategories.FirstOrDefault(cat => cat.Id == id);
        }

        public Category Update(int id, Category item)
        {
            Category catToUpdate = this.MockedUpCategories.FirstOrDefault(cat => cat.Id == id);
            if (catToUpdate == null)
            {
                throw new Exception("No Category with this ID is present to update");
            }

            catToUpdate.Name = item.Name;
            catToUpdate.Description = item.Description;
            catToUpdate.CatPictures = item.CatPictures;

            return catToUpdate;
        }
    }
}
