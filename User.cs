using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Login
{
    public class User
    {
        List<ACCESS> access;
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

        public List<ACCESS> GetAccess()
        {
            return access;
        }

        public void AddAccess(ACCESS access)
        {
            this.access.Add(access);
        }

        public void RemoveAccess(ACCESS access)
        {
            this.access.Remove(access);
        }

        public void SaveAccess()
        {
            AccessManager.SaveUserAccess(this);
        }
    }
}
