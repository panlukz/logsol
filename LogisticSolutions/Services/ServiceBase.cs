using System;
using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
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

        protected TrackingStatus GenerateTrackingPoint(TrackingStatusEnum status)
        {
            return new TrackingStatus()
            {
                Author = CurrentUser.Id,
                DateTime = DateTime.Now,
                Status = status,
                Location = CurrentUser.UserInfo.Location
            };
        }
    }
}