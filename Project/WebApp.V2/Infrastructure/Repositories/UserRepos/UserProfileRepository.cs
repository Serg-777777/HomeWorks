

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository: IUserProfileRepository
    {
        UserContext _context =default!;
        public UserProfileRepository(UserContext context)
        {
            _context = context;
        }

        public List<UserProfileModel> Entities => _context.Profiles.ToList();

        public UserProfileModel? AddEntity(UserProfileModel entity)
        {
           var prof = _context.Profiles.Add(entity).Entity;
            return prof;
        }
        
        public UserProfileModel? GetEntity(int idUser)
        {
            var prof = _context.Profiles.FirstOrDefault(p => p.UserId == idUser);
            return prof;
        }

        public bool RemoveEntity(int idUser)
        {
            var prof = _context.Profiles.FirstOrDefault(p => p.User!.Id == idUser);
            if(prof!=null)
            {
                var res = _context.Profiles.Remove(prof);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserProfileModel? UpdateEntity(int idUser, UserProfileModel entity)
        {
            var prof = _context.Profiles.FirstOrDefault(p => p.User!.Id == idUser);
            if (prof != null)
            {
                prof.SetValues(entity);
                var res = _context.Profiles.Update(prof);
                _context.SaveChanges();
                return res.Entity;
            }
            return null;
        }
    }
}
