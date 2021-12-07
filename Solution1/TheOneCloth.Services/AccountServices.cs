using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using System.Data.Entity;

namespace TheOneCloth.Services
{
   public class AccountServices
    {
        #region Singleton
        public static AccountServices Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountServices();
                return instance;
            }
        }

        private static AccountServices instance { get; set; }

        private AccountServices()
        {

        }
        #endregion
        public async Task<Users> Login(string UserName,string Password)
        {
            Users user = new Users();
            using (TOContext db=new TOContext())
            {
                user = await db.Users.FirstOrDefaultAsync(x => x.UserName == UserName || x.Email == UserName  && x.Password == Password);
            }
            return user;
        }

        public async Task  Register(string name,string email,string password)
        {
            Users user = new Users();
            using (TOContext db=new TOContext())
            {
                user.UserName = name;
                user.Email = email;
                user.Password = password;
                user.Roles = "User";
                db.Users.Add(user);
               await db.SaveChangesAsync();
            }
            
        }

    }
}
