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
        Task<PhotoReturnDto> GetPhoto(int id);
        Task<Photo> AddPhotoForComponent(PhotoToCreateDto photo);
        Task<int> Done();
    }
}
