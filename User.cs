using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Login
{
    internal class User
    {
        List<AccessManager.ACCESS> access;
        string username;
        byte[] salt;

        public User(string username, byte[] salt)
        {
            this.username = username;
            this.salt = salt;
            access = AccessManager.GetUserAccess(this);
        }

        public string GetUsername()
        {
            return username;
        }

        public List<AccessManager.ACCESS> GetAccess()
        {
            return access;
        }
    }
}
