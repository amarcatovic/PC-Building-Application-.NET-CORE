using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.Models.Dtos
{
    public class PhotoToCreateDto
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
        public DateTime DateAdded { get; set; }

        public PhotoToCreateDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}
