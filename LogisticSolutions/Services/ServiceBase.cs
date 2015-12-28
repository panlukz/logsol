using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Services
{
    public abstract class ServiceBase
    {
        protected readonly IDataFactory _dataFactory;
        protected readonly ApplicationUser _currentUser;

        protected ServiceBase(IDataFactory dataFactory, ApplicationUser user = null)
        {
            _dataFactory = dataFactory;
            _currentUser = user ??
                           HttpContext.Current.GetOwinContext()
                               .GetUserManager<ApplicationUserManager>()
                               .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }
    }
}