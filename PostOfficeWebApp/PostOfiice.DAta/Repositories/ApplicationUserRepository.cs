using PostOffice.Model.Models;
using PostOfiice.DAta.Infrastructure;
using System.Linq;
using System;

namespace PostOfiice.DAta.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        int getNoUserByPoID(int PoID);
        string getIdByUserName(string userName);
    }

    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public string getIdByUserName(string userName)
        {
            var user = this.DbContext.Users.Where(x => x.UserName.Contains(userName)).FirstOrDefault();
            return user.Id;
        }

        public int getNoUserByPoID(int PoID)
        {
            return this.DbContext.Users.Where(x => x.POID == PoID).Count();
        }
    }
}