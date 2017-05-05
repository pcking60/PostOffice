using PostOffice.Model.Models;
using PostOfiice.DAta.Infrastructure;
using System.Linq;

namespace PostOfiice.DAta.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        int getNoUserByPoID(int PoID);
    }

    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int getNoUserByPoID(int PoID)
        {
            return this.DbContext.Users.Where(x => x.POID == PoID).Count();
        }
    }
}