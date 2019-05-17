using MVCAgeCheck.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCAgeCheck
{
    public class DALContext : DbContext
    {
        public DALContext() { }

        public DALContext(DbContextOptions options) : base(options) { }

        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }

        public virtual IQueryable<Login> GetLogins => Logins.Include(x => x.User);

        public IQueryable<User> GetUsers=> Users.Include(x => x.Logins);

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public void AddLogin(Login login)
        {
            Logins.Add(login);
        }

        public void RemoveLogin(Login login)
        {
            Logins.Remove(login);
        }

        public virtual User GetUserByNameAndEmail(string name, string email)
        {
            return Users.SingleOrDefault(x => x.Name == name && x.Email == email);
        }
    }
}
