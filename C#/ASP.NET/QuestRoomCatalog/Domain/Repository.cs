using ASP_HW4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW4.Domain
{
    public class Repository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<QuestRoom>> GetQuestRooms()
        {
            return await _context.QuestRooms.AsNoTracking().Select(x => new QuestRoom {Id = x.Id, Title = x.Title, Difficulty = x.Difficulty, FearLevel = x.FearLevel, Quest = x.Quest, PlayersNumber = x.PlayersNumber }).ToListAsync();
        }

        public async Task<ICollection<string>> GetDiffNames()
        {
            return await _context.Difficulties.AsNoTracking().Select(x => x.Title).ToListAsync();
        }
        public async Task<ICollection<string>> GetFLNames()
        {
            return await _context.FearLevels.AsNoTracking().Select(x => x.Title).ToListAsync();
        }
        public async Task<ICollection<int>> GetPNumbers()
        {
            return await _context.PlayersNumbers.AsNoTracking().Select(x => x.Number).ToListAsync();
        }
        public async Task<ICollection<QuestRoom>> GetQuestRoomDetails(int id)
        {
            return await _context.QuestRooms.AsNoTracking().Where(x => x.Id==id).Select(x=>new QuestRoom { 
            Title = x.Title, Quest = x.Quest, Details = x.Details, Difficulty = x.Difficulty, FearLevel = x.FearLevel,
            PlayersNumber= x.PlayersNumber
            }).ToListAsync();
        }
        public async Task<ICollection<QuestRoom>> GetQuestRoomsByDiff(string diff)
        {
            return await _context.QuestRooms.AsNoTracking().Where(x => x.Difficulty.Title == diff).Select(x => new QuestRoom
            {
                Title = x.Title,
                Quest = x.Quest,
                Details = x.Details,
                Difficulty = x.Difficulty,
                FearLevel = x.FearLevel,
                PlayersNumber = x.PlayersNumber
            }).ToListAsync();
        }
        public async Task<ICollection<QuestRoom>> GetQuestRoomsByFl(string fl)
        {
            return await _context.QuestRooms.AsNoTracking().Where(x => x.FearLevel.Title == fl).Select(x => new QuestRoom
            {
                Title = x.Title,
                Quest = x.Quest,
                Details = x.Details,
                Difficulty = x.Difficulty,
                FearLevel = x.FearLevel,
                PlayersNumber = x.PlayersNumber
            }).ToListAsync();
        }
        public async Task<ICollection<QuestRoom>> GetQuestRoomsByPn(int pn)
        {
            return await _context.QuestRooms.AsNoTracking().Where(x => x.PlayersNumber.Number == pn).Select(x => new QuestRoom
            {
                Title = x.Title,
                Quest = x.Quest,
                Details = x.Details,
                Difficulty = x.Difficulty,
                FearLevel = x.FearLevel,
                PlayersNumber = x.PlayersNumber
            }).ToListAsync();
        }
    }
}
