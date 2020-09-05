using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Repositories.Interfaces
{
    public interface IPhotoRepo
    {
        Task AddPhoto(Photo photo);
        Task<Photo> GetPhoto(int id);
        Task<Photo> AddPhotoForComponent(int componentId, PhotoToCreateDto photo);
        Task<int> Done();
    }
}
