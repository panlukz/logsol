using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogisticSolutions.DAL;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions
{
    public class IdentityDbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        private const string DefaultPassword = "passwd";

        protected override void Seed(DataContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roles = new string[] {"Admin", "Warehouseman", "Courier", "Customer"};

            var newUsers = new ApplicationUser[]
            {
                new ApplicationUser()
                {
                    UserName = "jacek_admin_wwa", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Jacek", LastName = "Placek", Location = "Warszawa"}
                },
                new ApplicationUser()
                {
                    UserName = "adam_magazyn_ldz", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Adam", LastName = "Pierwszy", Location = "Łódź"}
                },
                new ApplicationUser()
                {
                    UserName = "wanda_magazyn_gda", UserInfo = new UserInfo() {FirstName = "Wanda", LastName = "Wielka", Location = "Gdańsk"}
                },
                new ApplicationUser()
                {
                    UserName = "rafal_kurier_ldz", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Rafał", LastName = "Konieczny", Location = "Łódź"}
                },
                new ApplicationUser()
                {
                    UserName = "pawel_kurier_gda", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Paweł", LastName = "Szczęsny", Location = "Gdańsk"}
                },
                new ApplicationUser()
                {
                    UserName = "waclaw_klient_ldz", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Wacław", LastName = "Trąba", Location = "Łódź"}
                },
                new ApplicationUser()
                {
                    UserName = "andrzej_klient_gda", Email = "none@none.pl", UserInfo = new UserInfo() {FirstName = "Andrzej", LastName = "Szybki", Location = "Gdańsk"}
                }
            };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                    roleManager.Create(new IdentityRole(role));
            }

            foreach (var newUser in newUsers)
            {
                var userCreateResult = userManager.Create(newUser, DefaultPassword);

                if (userCreateResult.Succeeded)
                {
                    string roleName = String.Empty;

                    switch (newUser.UserName.Split('_')[1])
                    {
                        case "admin":
                            roleName = "Admin";
                            break;

                        case "magazyn":
                            roleName = "Warehouseman";
                            break;

                        case "kurier":
                            roleName = "Courier";
                            break;

                        case "klient":
                            roleName = "Customer";
                            break;

                        default:
                            throw new Exception("Zła rola w systemie!");
                    }

                    var userAddToRoleResult = userManager.AddToRole(newUser.Id, roleName);
                }
            }

            base.Seed(context);
        }
    }
}