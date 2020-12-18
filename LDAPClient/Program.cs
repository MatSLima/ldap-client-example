using System;

namespace LDAPClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            LDAP ldap = new LDAP();
            
            ldap.CreateUser(username: "test", password: "123456");
            bool authenticated = ldap.Authenticate(username: "test", password: "123456");
            
            Console.WriteLine(string.Format("Is authenticated: {0}", authenticated));
        }
    }
}