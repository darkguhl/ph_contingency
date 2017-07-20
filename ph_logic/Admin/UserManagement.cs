using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using ph_model;

namespace ph_logic.Admin
{
    public static class UserManagement
    {
        public static void CreateUser(User user, RoleType roleType)
        {
            using (var db = PhContext.CreateContext())
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrPass = crypto.Compute(user.Password);
                var sysUser = db.UserSet.Create();

                sysUser.Username = user.Username;
                sysUser.Email = user.Email;
                sysUser.Password = encrPass;
                sysUser.PasswordSalt = crypto.Salt;
                sysUser.RoleType = roleType;

                db.UserSet.Add(sysUser);
                db.SaveChanges();

            }
        }
    }
}
