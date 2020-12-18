using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Novell.Directory.Ldap;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

namespace LDAPClient
{
    public class LDAP
    {
        public LdapConnection cn { get; set; }

        public LDAP() => cn = new LdapConnection();
        
        public void CreateUser(string username, string password)
        {
            string domain = string.Format("uid={0},ou=users,dc=jogoglobal,dc=com", username);
            
            cn.Connect("localhost", 389);
            cn.Bind("uid=admin,ou=system", "secret");

            LdapAttributeSet attrs = new LdapAttributeSet();
            attrs.Add(new LdapAttribute("uid", username));
            attrs.Add(new LdapAttribute("userPassword", password));
            attrs.Add(new LdapAttribute("ou", "users"));
            attrs.Add(new LdapAttribute("objectClass", new string[] { "top", "account", "simpleSecurityObject" }));
            
            LdapEntry entry = new LdapEntry(domain, attrs);
            cn.Add(entry);
        }
        
        public bool Authenticate(string username, string password)
        {
            string domain = string.Format("uid={0},ou=users,dc=jogoglobal,dc=com", username);
            LdapAttribute passwordAttr = new LdapAttribute("userPassword", password);
            cn.Connect("localhost", 389);
            cn.Bind("uid=admin,ou=system", "secret");
            return cn.Compare(domain, passwordAttr);
        }
    }
}