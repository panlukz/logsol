using System;
using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Services
{
    public abstract class ServiceBase
    {
        protected readonly IDataFactory DataFactory;
        protected readonly ApplicationUser CurrentUser;

        protected ServiceBase(IDataFactory dataFactory, ApplicationUser user = null)
        {
            DataFactory = dataFactory;
            CurrentUser = user ??
                           HttpContext.Current.GetOwinContext()
                               .GetUserManager<ApplicationUserManager>()
                               .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        protected TrackingHistoryPoint GenerateTrackingPoint(TrackingStatus status, string location=null)
        {
            return new TrackingHistoryPoint()
            {
                Author = CurrentUser.Id,
                DateTime = DateTime.Now,
                Status = status,
                Location = location ?? CurrentUser.UserInfo.Location
            };
        }
    }
}