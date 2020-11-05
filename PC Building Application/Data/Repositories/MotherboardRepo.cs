using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PC_Building_Application.Data.Repositories
{
    public class MotherboardRepo : IMotherboardRepo
    {
        private readonly DataContext _context;
        private readonly IPhotoRepo _photoRepo;
        private readonly IMapper _mapper;

        public MotherboardRepo(DataContext context, IPhotoRepo photoRepo, IMapper mapper)
        {
            _context = context;
            _photoRepo = photoRepo;
            _mapper = mapper;
        }
        public async Task<MotherboardReadDto> CreateMotherboard(MotherboardCreateDto motherboardCreateDto)
        {
            var photoToCreate = new PhotoToCreateDto()
            {
                Description = motherboardCreateDto.PhotoDescription,
                File = motherboardCreateDto.PhotoFile
            };
            
            var motherboard = _mapper.Map<Motherboard>(motherboardCreateDto);
            
            var createdPhoto = await _photoRepo.AddPhotoForComponent(photoToCreate);
            if (createdPhoto == null)
                return null;

            motherboard.PhotoId = createdPhoto.Id;
            await _context.Motherboards.AddAsync(motherboard);

            return _mapper.Map<MotherboardReadDto>(motherboard);
        }

        public async Task<IEnumerable<MotherboardReadDto>> GetAllMotherboards()
        {
            var motherboards = await _context.Motherboards
                .Include(m => m.Photo)
                .Include(m => m.Manufacturer)
                .Include(m => m.SocketType)
                .ToListAsync();

            return _mapper.Map<IEnumerable<MotherboardReadDto>>(motherboards);
        }

        public async Task<MotherboardReadDto> GetMotherboardById(int id)
        {
            var motherboard = await _context.Motherboards
                .Include(m => m.Photo)
                .Include(m => m.Manufacturer)
                .Include(m => m.SocketType)
                .SingleOrDefaultAsync(m => m.Id == id);

            return _mapper.Map<MotherboardReadDto>(motherboard);
        }

        public async Task<int> Done()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
