using System;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Services;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace TWH.Services
{
    public class CatManager
    {
        public CatService catService { get; set; }
        public CatImageService catImageService { get; set; }

        public CatManager(UnitOfWork unitOfWork)
        {
            catService = new CatService(unitOfWork);
            catImageService = new CatImageService(unitOfWork);
        }
        public Cat SearchFor(Guid id)
        {
            return catService.GetById(id);
        }
        public void Create(Cat cat)
        {
            catService.Insert(cat);
            catService.SaveChanges();
        }
        //TODO check HttpPostedFileBase for Images being inserted.
        public void Update(Cat cat, IFormFile newImage, bool? removeOldImage)
        {
            catImage mImage = newImage.
        }


        
    }
}
