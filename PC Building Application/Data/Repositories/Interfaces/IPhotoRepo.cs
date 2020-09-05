using PC_Building_Application.Data.Models;
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
        Task<Photo> AddPhotoForComponent(int componentId);
        Task<int> Done();
    }
}
