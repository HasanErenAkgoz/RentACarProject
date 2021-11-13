using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Core.CrossCuttingConcerns.Security
{
    class Identity : IIdentity
    {
        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
        public int TcKimlik { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string[] _roles { get; set; }
    }
}
