

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository: IUserProfileRepository
    {
        UserContext _context =default!;
        public UserProfileRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<UserProfileModel>> EntitiesAsync ()
        { 
           var list = await _context.Profiles.ToListAsync();
            return list;
        }

        public async Task<UserProfileModel>? AddEntityAsync(UserProfileModel entity)
        {
           var profEntity = await _context.Profiles.AddAsync(entity);
           await _context.SaveChangesAsync();
            var prof = profEntity.Entity;
            return prof;
        }
        
        public async Task<UserProfileModel>? GetEntityAsync(int idUser)
        {
            var prof = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == idUser);
            return prof!;
        }

        public async Task<bool> RemoveEntityAsync(int idUser)
        {
            var prof = await GetEntityAsync(idUser)!;
            if(prof!=default)
            {
                var res = _context.Profiles.Remove(prof);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async  Task<UserProfileModel>? UpdateEntityAsync(int idUser, UserProfileModel entity)
        {
            var prof = await GetEntityAsync(idUser)!;
            if (prof != default)
            {
                prof.SetValues(entity);
                var res = _context.Profiles.Update(prof);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            return null!;
        }
    }
}
