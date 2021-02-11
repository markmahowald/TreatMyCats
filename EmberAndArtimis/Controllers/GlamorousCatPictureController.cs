using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmberAndArtimis.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmberAndArtimis.Controllers
{
    public class GlamorousCatPictureController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<GlamorousCatPicture> _glamorousCatPictureRepository;

        public GlamorousCatPictureController(IGenericRepository<GlamorousCatPicture> catPicRepo, IGenericRepository<Category> categoryRepo)
        {
            this._categoryRepo = categoryRepo;
            this._glamorousCatPictureRepository = catPicRepo;
        }

        public ViewResult List()
        {
            List<GlamorousCatPicture> picsForView = new List<GlamorousCatPicture>();
            List<Category> categories = _categoryRepo.GetAll().ToList();
            foreach (GlamorousCatPicture catPic in _glamorousCatPictureRepository.GetAll())
            {
                picsForView.Add(catPic);
                catPic.Category = categories.FirstOrDefault(category => category.Id == catPic.CategoryId);
            }
            return View(picsForView);
        }
    }
}
