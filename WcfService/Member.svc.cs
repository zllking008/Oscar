using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Model;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Member : IMember
    {
        public User GetUser(string id)
        {
            DbDomain.TestDbHandlerDataContext dc=new DbDomain.TestDbHandlerDataContext();
            return (from x in dc.Member where x.Id.ToString().Equals(id) select new User { Id = x.Id, Name = x.Name }).FirstOrDefault();
        }
        public int AddUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) return -1;
            DbDomain.TestDbHandlerDataContext dc = new DbDomain.TestDbHandlerDataContext();
            DbDomain.Member clsMember = new DbDomain.Member();
            clsMember.Name = name;
            clsMember.Password = password;
            dc.Member.InsertOnSubmit(clsMember);
            dc.SubmitChanges();
            return clsMember.Id;
        }

    }
}
